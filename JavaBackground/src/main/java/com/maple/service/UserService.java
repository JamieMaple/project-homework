package com.maple.service;

import com.maple.helper.Convert;
import com.maple.helper.PageRequest;
import com.maple.model.User;
import com.maple.model.UserType;
import com.maple.repository.UserRepository;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.JwtException;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import java.security.Key;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.spec.InvalidKeySpecException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;
    
    public List<User> getUserList(int limit, int offset) {
        var users = new ArrayList<User>();
        userRepository
                .findAll(new PageRequest(offset, limit))
                .forEach(users::add);
        return users;
    }
    
    /*
     * password related
     */
    class PasswordGroup {
        public String hashPassword;
        
        public String salt;
    }
    
    private static final int iterationCount = 10000;
    private static final int numBytesRequest = 256;
    private static final int saltNumByte = 128 / 8;
    
    public PasswordGroup hashPassword(String password) {
        var group = new PasswordGroup();
        var salt = generateSalt();
        try {
            var hashPassword = hashPasswordWithSalt(password, salt);
            group.hashPassword = hashPassword;
            group.salt = Convert.toBase64String(salt);
            
        } catch (Exception err) {
            throw new RuntimeException(err);
        }
        return group;
    }
    
    private byte[] generateSalt() {
        var bytes = new byte[saltNumByte];
        var random = new SecureRandom();
        random.nextBytes(bytes);
        
        return bytes;
    }
    
    private String hashPasswordWithSalt(String password, String salt)
            throws NoSuchAlgorithmException, InvalidKeySpecException {
        return hashPasswordWithSalt(password, Convert.fromBase64String(salt));
    }
    
    private String hashPasswordWithSalt(String password, byte[] salt)
            throws NoSuchAlgorithmException, InvalidKeySpecException {
        var spec = new PBEKeySpec(password.toCharArray(), salt, iterationCount, numBytesRequest);
        var secretFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256");
        var secretKey = secretFactory.generateSecret(spec);
        var codeBytes = secretKey.getEncoded();
        
        return Convert.toBase64String(codeBytes);
    }
    
    private boolean Authorization(String password, User user) {
        try {
            return hashPasswordWithSalt(password, user.getSalt()).compareTo(user.getPassword()) == 0;
        } catch (Exception err) {
            return false;
        }
    }
    
    public String getUserToken(String username, String password) {
        var user = userRepository.findFirstByUsername(username);
        if (user != null && Authorization(password, user)) {
            return buildToken(user);
        } else {
            return "";
        }
    }
    
    private static final Key SECRET_TOKEN = Keys.secretKeyFor(SignatureAlgorithm.HS256);
    private static final long DAY = 24 * 60 * 60 * 1000;
    private static final String ROLE = "role";
    
    public String buildToken(User user) {
        var now = new Date();
        var exp = new Date(now.getTime() + DAY);
        return Jwts.builder()
                       .setId(Long.toString(user.getId()))
                       .claim(ROLE, user.getType())
                       .setExpiration(exp)
                       .signWith(SECRET_TOKEN)
                       .compact();
    }
    
    private Claims parseToken(String token) {
        try {
            return Jwts.parser().setSigningKey(SECRET_TOKEN).parseClaimsJws(token.trim()).getBody();
        } catch (JwtException err) {
            return null;
        }
    }
    
    public User getUserFromToken(String token) {
        var user = new User();
        var claims = parseToken(token);
        try {
            var idString = claims.getId();
            var id = Long.valueOf(idString);
            
            var type = claims.get(ROLE);
            var userType = UserType.valueOf((String)type);
            
            user.setId(id);
            user.setType(userType);
        } catch (Exception err) {
            return null;
        }
        
        return user;
    }
    
    public void deleteUserById(long id) {
        userRepository.deleteById(id);
    }
}

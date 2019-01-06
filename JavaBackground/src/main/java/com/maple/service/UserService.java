package com.maple.service;

import com.maple.helper.PageRequest;
import com.maple.model.User;
import com.maple.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.persistence.Tuple;
import java.util.ArrayList;
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
    
    class PasswordGroup {
        public String password;
        
        public String salt;
    }
    
    public String login(String username, String password) {
//        TODO: login
        return "";
    }
    
    private PasswordGroup hashPassword(String username, String password) {
//        TODO: save password
        var group = new PasswordGroup();
        
        return group;
    }
    
    public void deleteUserById(long id) {
        userRepository.deleteById(id);
    }
}

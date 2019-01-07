package com.maple.graphql.query;

import com.maple.graphql.AuthContext;
import com.maple.graphql.ClientError;
import com.maple.model.User;
import com.maple.service.UserService;
import graphql.schema.DataFetchingEnvironment;

import java.util.List;

class UserInput {
    public String username;
    
    public String password;
}

public class UserQuery {
    private UserService userService;
    
    public UserQuery(UserService userService) {
        this.userService = userService;
    }
    
    public List<User> getUserList(int limit, int offset, DataFetchingEnvironment env) {
        
        if (!AuthContext.isAdmin(env)) {
            ClientError.addPermissionError(env);
            return null;
        }
        
        return userService.getUserList(limit, offset);
    }
    
    public String token(UserInput user) {
        var username = user.username.trim();
        var password = user.password.trim();
        if (username.isEmpty() || password.isEmpty()) {
            return "";
        }
        return userService.getUserToken(username, password);
    }
}

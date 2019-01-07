package com.maple.graphql.mutation;

import com.maple.model.User;
import com.maple.service.UserService;

public class UserMutation {
    private UserService userService;
    
    public UserMutation(UserService userService) {
        this.userService = userService;
    }
    
    public boolean changeUserPassword(User user) {
        return false;
    }
    
    public boolean deleteUser(int deleteId) {
        return false;
    }
    
    public boolean newWaiter(User user) {
        return false;
    }
}

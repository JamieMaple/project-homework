package com.maple.Models;

public class User extends Base {
    public String username;
    
    private String password;
    
    private String salt;
    
    private UserType type;
    
    public void setPassword(String password) {
        this.password = password;
    }
}

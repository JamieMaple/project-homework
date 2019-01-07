package com.maple.model;

import lombok.Getter;

import javax.persistence.Column;
import javax.persistence.Entity;

@Entity
public class User extends Base {
    private String username;
    
    private String password;
    
    private String salt;
    
    @Column(columnDefinition = "int")
    private int type;
    
    public UserType getType() {
        return UserType.parse(type);
    }
    
    public String getPassword() {
        return password;
    }
    
    public String getSalt() {
        return salt;
    }
    
    public void setType(UserType type) {
        this.type = type.getValue();
    }
}

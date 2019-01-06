package com.maple.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;

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
}

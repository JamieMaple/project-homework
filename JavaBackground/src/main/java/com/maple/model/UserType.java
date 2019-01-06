package com.maple.model;

public enum UserType {
    NORMAL(1),
    WAITER(2),
    ADMIN(4),
    ROOT(8);
    
    private final int value;
    
    private UserType(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
    
    public static UserType parse(int userType) {
        UserType user = null;
        
        for (var s : UserType.values()) {
            if (s.getValue() == userType) {
                user = s;
                break;
            }
        }
        
        return user;
    }
}

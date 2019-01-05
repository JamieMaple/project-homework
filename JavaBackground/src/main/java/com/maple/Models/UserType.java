package com.maple.Models;

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
}

package com.maple.Models;

public enum OrderStatus {
    Created(1),
    Pending(2),
    Finsihed(4);
    
    private final int value;
    private OrderStatus(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
}

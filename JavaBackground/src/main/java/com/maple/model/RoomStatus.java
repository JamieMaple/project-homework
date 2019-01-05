package com.maple.model;

public enum RoomStatus {
    IDLE(1),
    BUSY(2);
    
    private int value;
    
    private RoomStatus(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
}


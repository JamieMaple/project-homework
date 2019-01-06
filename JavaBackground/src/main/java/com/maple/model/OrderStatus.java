package com.maple.model;

import java.util.Arrays;

public enum OrderStatus {
    CREATED(1),
    PENDING(2),
    FINISHED(4);

    private final int value;
    private OrderStatus(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
    
    public static OrderStatus parse(int statusId) {
        OrderStatus status = null;
    
        for (var s : OrderStatus.values()) {
            if (s.getValue() == statusId) {
                status = s;
                break;
            }
        }
        
        return status;
    }
    
}

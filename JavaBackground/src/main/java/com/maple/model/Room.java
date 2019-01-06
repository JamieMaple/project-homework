package com.maple.model;

import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;

@Entity
public class Room extends Base {
    private String name;
    
    private int floor;
    
    @Enumerated(EnumType.ORDINAL)
    private RoomStatus status;
    
    private long lastUpdateAt;
}

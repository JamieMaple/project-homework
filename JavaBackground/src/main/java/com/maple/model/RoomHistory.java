package com.maple.model;

import javax.persistence.EnumType;
import javax.persistence.Enumerated;

public class RoomHistory extends Base {
    private int roomId;
    
    private int waiterId;
    
    private String name;
    
    @Enumerated(EnumType.ORDINAL)
    private RoomStatus status;
}

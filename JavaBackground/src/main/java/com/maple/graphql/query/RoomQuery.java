package com.maple.graphql.query;

import com.maple.model.Room;
import com.maple.service.RoomService;

import java.util.List;

public class RoomQuery {
    private RoomService roomService;
    
    public RoomQuery(RoomService roomService) {
        this.roomService = roomService;
    }
    
    public List<Room> rooms(int limit, int offset) {
        return roomService
                       .getRoomList(limit, offset);
    }
}

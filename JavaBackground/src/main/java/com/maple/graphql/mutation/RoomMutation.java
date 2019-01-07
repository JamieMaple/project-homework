package com.maple.graphql.mutation;

import com.maple.model.Room;
import com.maple.model.RoomStatus;
import com.maple.service.RoomService;

public class RoomMutation {
    private RoomService roomService;
    
    public RoomMutation(RoomService roomService) {
        this.roomService = roomService;
    }
    
    public boolean changeRoomStatus(int roomId, RoomStatus status) {
        return false;
    }
    
    public boolean createRoom(Room room) {
        return false;
    }
    
    public boolean deleteRoom(int roomId) {
        return false;
    }
    
    public boolean updateRoom(int roomId, Room room) {
        return false;
    }
}

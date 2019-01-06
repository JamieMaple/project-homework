package com.maple.service;

import com.maple.helper.PageRequest;
import com.maple.model.Room;
import com.maple.repository.RoomRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class RoomService {
    @Autowired
    private RoomRepository roomRepository;
    
    public List<Room> getRoomList(int limit, int offset) {
        var rooms = new ArrayList<Room>();
        roomRepository
                .findAll(new PageRequest(offset, limit))
                .forEach(rooms::add);
        return rooms;
    }
    
    public Room createRoom(Room room) {
        return roomRepository.save(room);
    }
    
    public Room updateRoom(Room room) {
        return roomRepository.save(room);
    }
    
    public void deleteRoomById(long id) {
        roomRepository.deleteById(id);
    }
}

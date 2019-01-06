package com.maple.repository;

import com.maple.model.Room;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface RoomRepository extends CrudRepository<Room, Long> {
    Iterable<Room> findAll(Pageable pageable);
}

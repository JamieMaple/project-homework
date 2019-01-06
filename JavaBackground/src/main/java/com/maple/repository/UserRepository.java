package com.maple.repository;

import com.maple.model.User;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface UserRepository extends CrudRepository<User, Long> {
    Iterable<User> findAll(Pageable pageable);
}

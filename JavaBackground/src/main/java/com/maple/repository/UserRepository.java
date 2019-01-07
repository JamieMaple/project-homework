package com.maple.repository;

import com.maple.model.User;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface UserRepository extends CrudRepository<User, Long> {
    Iterable<User> findAll(Pageable pageable);
    
    User findFirstByUsername(String username);
}

package com.maple.repository;

import com.maple.model.Order;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface OrderRepository extends CrudRepository<Order, Long> {
    Iterable<Order> findAll(Pageable pageable);
}

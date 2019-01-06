package com.maple.repository;

import com.maple.model.Food;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface FoodRepository extends CrudRepository<Food, Long> {
    Iterable<Food> findAll(Pageable pageable);
}

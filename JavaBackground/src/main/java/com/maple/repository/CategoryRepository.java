package com.maple.repository;

import com.maple.model.Category;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface CategoryRepository extends CrudRepository<Category, Long> {
    Iterable<Category> findAll(Pageable pageable);
}

package com.maple.service;

import com.maple.helper.PageRequest;
import com.maple.model.Category;
import com.maple.model.Food;
import com.maple.repository.CategoryRepository;
import com.maple.repository.FoodRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class FoodService {
    @Autowired
    private FoodRepository foodRepository;
    
    @Autowired
    private CategoryRepository categoryRepository;
    
    public List<Food> getFoodList(int limit, int offset) {
        var foods = new ArrayList<Food>();
        foodRepository
                .findAll(new PageRequest(offset, limit))
                .forEach(foods::add);
        return foods;
    }
    
    public List<Category> getCategoryList(int limit, int offset) {
        var categories = new ArrayList<Category>();
        categoryRepository
                .findAll(new PageRequest(offset, limit))
                .forEach(categories::add);
        return categories;
    }
    
    public Food createFood(Food food) {
        return foodRepository.save(food);
    }
    
    public Food updateFood(Food food) {
        return foodRepository.save(food);
    }
    
    public void deleteFoodId(long id) {
        foodRepository.deleteById(id);
    }
}

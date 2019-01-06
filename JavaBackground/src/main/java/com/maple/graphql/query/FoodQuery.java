package com.maple.graphql.query;

import com.maple.model.Category;
import com.maple.model.Food;
import com.maple.service.FoodService;

import java.util.List;

public class FoodQuery {
    private FoodService foodService;
    
    public FoodQuery(FoodService foodService) {
        this.foodService = foodService;
    }
    
    public List<Food> foods(int limit, int offset) {
        return foodService.getFoodList(limit, offset);
    }
    
    public List<Category> categories(int limit, int offset) {
        return foodService.getCategoryList(limit, offset);
    }
}

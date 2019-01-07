package com.maple.graphql.mutation;

import com.maple.model.Food;
import com.maple.service.FoodService;

public class FoodMutation {
    private FoodService foodService;
    
    public FoodMutation(com.maple.service.FoodService foodService) {
        this.foodService = foodService;
    }
    
    public boolean createFood(Food food) {
        return false;
    }
    
    public boolean deleteFood(int foodId) {
        return false;
    }
    
    public boolean updateFood(int foodId, Food food) {
        return false;
    }
}

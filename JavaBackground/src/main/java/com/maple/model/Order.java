package com.maple.model;

import com.fasterxml.jackson.databind.MapperFeature;
import com.fasterxml.jackson.databind.ObjectMapper;

import javax.persistence.*;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;

@Entity
@Table(name = "\"order\"")
public class Order extends Base {
    private static ObjectMapper objectMapper = new ObjectMapper().configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_PROPERTIES, true);
    private int roomId;
    
    private int waiterId;
    
    private double totalPrice;
    
    @Column(name = "food_list", columnDefinition = "json")
    private String foodList;
    
    public List<FoodListItem> getFoodList() throws IOException {
        var foods = Arrays.asList(objectMapper.readValue(foodList, FoodListItem[].class));
        return foods;
    }
    
    @Column(columnDefinition = "int")
    private int status;
    
    public OrderStatus getStatus() {
        return OrderStatus.parse(status);
    }
    
    private long finishAt;
}

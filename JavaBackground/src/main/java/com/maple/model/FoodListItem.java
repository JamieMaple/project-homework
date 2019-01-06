package com.maple.model;


import lombok.Data;

@Data
public class FoodListItem {
    private long id;
    private String name;
    private int count;
    private double unitPrice;
}

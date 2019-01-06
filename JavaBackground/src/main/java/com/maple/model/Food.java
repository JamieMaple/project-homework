package com.maple.model;

import lombok.Data;

import javax.persistence.Entity;

@Entity
public class Food extends Base {
    private String name;
    
    private Double unitPrice;
    
    private int categoryId;
    
    private String image;
    
    private String imgUrl;
}

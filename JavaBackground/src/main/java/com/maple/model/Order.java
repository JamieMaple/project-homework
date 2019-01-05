package com.maple.model;

public class Order extends Base {
    public int roomId;
    
    public int waiterId;
    
    public String foodList;
    
    public double totalPrice;
    
    public OrderStatus status;
    
    public long finishAt;
}

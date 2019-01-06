package com.maple.graphql.query;

import com.maple.model.Order;
import com.maple.service.OrderService;

import java.util.List;

public class OrderQuery {
    private OrderService orderService;
    
    public OrderQuery(OrderService orderService) {
        this.orderService = orderService;
    }
    
    public List<Order> orders(int limit, int offset) {
        return orderService
                       .getOrderList(limit, offset);
    }
}

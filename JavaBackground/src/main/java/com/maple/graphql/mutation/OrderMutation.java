package com.maple.graphql.mutation;

import com.maple.model.FoodListItem;
import com.maple.model.Order;
import com.maple.model.OrderStatus;
import com.maple.service.OrderService;

import java.util.List;

public class OrderMutation {
    private OrderService orderService;
    
    public OrderMutation(OrderService orderService) {
        this.orderService = orderService;
    }
    
    public boolean createOrder(Order order, List<FoodListItem> foodListItemList) {
        return false;
    }
    
    public boolean changeOrderStatus(int orderId, OrderStatus status) {
        return false;
    }
    
    public boolean deleteOrder(int orderId) {
        return false;
    }
}

package com.maple.service;

import com.maple.helper.PageRequest;
import com.maple.model.Order;
import com.maple.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class OrderService {
    @Autowired
    private OrderRepository orderRepository;
    
    public List<Order> getOrderList(int limit, int offset) {
        var orders = new ArrayList<Order>();
        orderRepository.findAll(new PageRequest(offset, limit)).forEach(orders::add);
        return orders;
    }
    
    public void deleteOrderyId(long id) {
        orderRepository.deleteById(id);
    }
}

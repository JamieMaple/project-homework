package com.maple.graphql;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.coxautodev.graphql.tools.GraphQLResolver;
import com.maple.graphql.query.FoodQuery;
import com.maple.graphql.query.OrderQuery;
import com.maple.graphql.query.RoomQuery;
import com.maple.graphql.query.UserQuery;
import com.maple.service.FoodService;
import com.maple.service.OrderService;
import com.maple.service.RoomService;
import com.maple.service.UserService;
import graphql.schema.DataFetchingEnvironment;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class RootQuery implements GraphQLQueryResolver {
    @Autowired
    private RoomService roomService;
    
    @Autowired
    private UserService userService;
    
    @Autowired
    private FoodService foodService;
    
    @Autowired
    private OrderService orderService;
    
    public RoomQuery getRoom() {
        return new RoomQuery(roomService);
    }
    
    public UserQuery getUser() {
        return new UserQuery(userService);
    }
    
    public OrderQuery getOrder(DataFetchingEnvironment env) {
        
        return new OrderQuery(orderService);
    }
    
    public FoodQuery getFood(DataFetchingEnvironment env) {
        if (!AuthContext.isLogin(env)) {
            ClientError.addPermissionError(env);
            return null;
        }
        
        return new FoodQuery(foodService);
    }
}

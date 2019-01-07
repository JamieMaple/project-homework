package com.maple.graphql;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.coxautodev.graphql.tools.GraphQLResolver;
import com.maple.graphql.mutation.FoodMutation;
import com.maple.graphql.mutation.OrderMutation;
import com.maple.graphql.mutation.RoomMutation;
import com.maple.graphql.mutation.UserMutation;
import com.maple.service.FoodService;
import com.maple.service.OrderService;
import com.maple.service.RoomService;
import com.maple.service.UserService;
import graphql.schema.DataFetchingEnvironment;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class RootMutation implements GraphQLMutationResolver {
    @Autowired
    private RoomService roomService;
    
    @Autowired
    private UserService userService;
    
    @Autowired
    private FoodService foodService;
    
    @Autowired
    private OrderService orderService;
    
    
    public RoomMutation room(DataFetchingEnvironment env) {
        if (!AuthContext.isAdmin(env)) {
            ClientError.addPermissionError(env);
            return null;
        }
        
        return new RoomMutation(roomService);
    }
    
    public UserMutation user(DataFetchingEnvironment env) {
        if (!AuthContext.isAdmin(env)) {
            ClientError.addPermissionError(env);
            return null;
        }
        
        return new UserMutation(userService);
    }
    
    public OrderMutation order(DataFetchingEnvironment env) {
        
        return new OrderMutation(orderService);
    }
    
    public FoodMutation food(DataFetchingEnvironment env) {
        if (!AuthContext.isLogin(env)) {
            ClientError.addPermissionError(env);
            return null;
        }
        
        return new FoodMutation(foodService);
    }
    
}

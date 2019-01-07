package com.maple.graphql;

import com.maple.model.User;
import com.maple.model.UserType;
import graphql.schema.DataFetchingEnvironment;
import graphql.servlet.GraphQLContext;

public class AuthContext extends GraphQLContext {
    private User user;
    
    public static boolean isLogin(DataFetchingEnvironment env) {
        AuthContext context = env.getContext();
        
        return context.isLogin();
    }
    
    public static boolean isAdmin(DataFetchingEnvironment env) {
        AuthContext context = env.getContext();
    
        return context.isAdmin();
    }
    
    public void setUser(User user) {
        this.user = user;
    }
    
    public User getUser() {
        return user;
    }
    
    public boolean isLogin() {
        return this.user != null;
    }
    
    public boolean isRoot() {
        return isLogin() && user.getType().getValue() >= UserType.ROOT.getValue();
    }
    
    public boolean isAdmin() {
        return isLogin() && user.getType().getValue() >= UserType.ADMIN.getValue();
    }
}

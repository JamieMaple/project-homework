package com.maple.graphql;

import com.maple.model.User;
import com.maple.service.UserService;
import graphql.servlet.GraphQLContext;
import graphql.servlet.GraphQLContextBuilder;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.websocket.Session;
import javax.websocket.server.HandshakeRequest;

@Component
public class AuthContextBuilder extends GraphQLContext implements GraphQLContextBuilder {
    @Autowired
    private UserService userService;
    
    private static final String AUTHORIZATION = "Authorization";
    
    private static final String AUTH_PREFIX = "Bearer ";
    
    @Override
    public GraphQLContext build(HttpServletRequest httpServletRequest, HttpServletResponse httpServletResponse) {
        var context = new AuthContext();
        
        var authorization = httpServletRequest.getHeader(AUTHORIZATION);
        if (authorization != null && authorization.startsWith(AUTH_PREFIX)) {
            authorization = authorization.replace(AUTH_PREFIX, "");
            var user = userService.getUserFromToken(authorization);
            context.setUser(user);
        }
        return context;
    }
    
    @Override
    public GraphQLContext build(Session session, HandshakeRequest handshakeRequest) {
        return new GraphQLContext();
    }
    
    @Override
    public GraphQLContext build() {
        var context = new AuthContext();
        return context;
    }
}

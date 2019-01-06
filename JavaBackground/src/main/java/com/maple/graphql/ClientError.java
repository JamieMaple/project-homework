package com.maple.graphql;

import com.fasterxml.jackson.annotation.JsonIgnore;
import graphql.ErrorType;
import graphql.GraphQLError;
import graphql.language.SourceLocation;

import java.util.List;
import java.util.Map;

public class ClientError extends RuntimeException implements GraphQLError {
    private String message;
    public ClientError(String message) {
        this.message = message;
    }
    
    @Override
    @JsonIgnore
    public List<SourceLocation> getLocations() {
        return null;
    }
    
    @Override
    @JsonIgnore
    public ErrorType getErrorType() {
        return ErrorType.ValidationError;
    }
    
    @Override
    @JsonIgnore
    public Map<String, Object> getExtensions() {
        return null;
    }
    
    @Override
    @JsonIgnore
    public StackTraceElement[] getStackTrace() {
        return super.getStackTrace();
    }
    
    @Override
    public String getMessage() {
        return message;
    }
}

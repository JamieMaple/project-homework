package com.maple.graphql;

import graphql.ErrorType;
import graphql.GraphQLError;
import graphql.language.SourceLocation;
import graphql.schema.DataFetchingEnvironment;

import java.util.List;

public class ClientError implements GraphQLError {
    @Override
    public List<SourceLocation> getLocations() {
        return null;
    }
    
    private String message;
    
    public static void addError(DataFetchingEnvironment env, String message) {
        env.getExecutionContext().addError(new ClientError(message));
    }
    
    public static void addPermissionError(DataFetchingEnvironment env) {
        addError(env, "Permission denied!");
    }
    
    public ClientError(String message) {
        this.message = message;
    }
    
    @Override
    public String getMessage() {
        return message;
    }
    
    @Override
    public ErrorType getErrorType() {
        return ErrorType.ExecutionAborted;
    }
}


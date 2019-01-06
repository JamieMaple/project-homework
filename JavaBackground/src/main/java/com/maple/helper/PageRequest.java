package com.maple.helper;

import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;

public class PageRequest implements Pageable {
    private int offset;
    private int limit;
    private Sort sort;
    
    public PageRequest(int offset, int limit) {
        this(offset, limit, new Sort(Sort.Direction.DESC, "createAt"));
    }
    
    public PageRequest(int offset, int limit, Sort sort) {
        this.offset = offset >= 0 ? offset : 0;
        this.limit = limit > 0 ? limit : 120;
        this.sort = sort;
    }
    
    @Override
    public int getPageNumber() {
        return offset / limit;
    }
    
    @Override
    public long getOffset() {
        return offset;
    }
    
    @Override
    public int getPageSize() {
        return limit;
    }
    
    @Override
    public Pageable first() {
        return new PageRequest(0, getPageSize(), getSort());
    }
    
    @Override
    public Pageable next() {
        var offset = (int)getOffset() + getPageSize();
        return new PageRequest(offset, getPageSize(), getSort());
    }
    
    @Override
    public boolean hasPrevious() {
        return offset > limit;
    }
    
    public Pageable previous() {
        var offset = (int)getOffset() - getPageSize();
        return hasPrevious() ? new PageRequest(offset, getPageSize(), getSort()) : this;
    }
    
    @Override
    public Pageable previousOrFirst() {
        return hasPrevious() ? previous() : first();
    }
    
    @Override
    public Sort getSort() {
        return this.sort;
    }
    
    @Override
    public String toString() {
        var builder = new StringBuilder();
        builder.append("offset = " + offset + ", ");
        builder.append("limit = " + limit + ", ");
        builder.append("sort = " + sort);
        return builder.toString();
    }
}

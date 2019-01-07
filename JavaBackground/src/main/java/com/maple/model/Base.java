package com.maple.model;

import javax.persistence.*;


@MappedSuperclass
public class Base {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
    
    private long createAt;
    
    private long deleteAt;
    
    public long getId() {
        return id;
    }
    
    public void setId(long id) {
        this.id = id;
    }
}

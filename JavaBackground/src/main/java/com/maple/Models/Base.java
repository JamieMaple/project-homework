package com.maple.Models;


import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

public class Base {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
    
    private long createAt;
    
    private long deleteAt;
    
    public long getId() {
        return id;
    }
    
    public long getCreateAt() {
        return createAt;
    }
    
    public void setCreateAt(long createAt) {
        this.createAt = createAt;
    }
    
    public long getDeleteAt() {
        return deleteAt;
    }
    
    public void setDeleteAt(long deleteAt) {
        this.deleteAt = deleteAt;
    }
    
}

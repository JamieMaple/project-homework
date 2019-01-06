package com.maple.model;

import javax.persistence.*;


@MappedSuperclass
public class Base {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
    
    private long createAt;
    
    private long deleteAt;
}

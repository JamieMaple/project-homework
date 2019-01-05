package com.maple;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MainController {
    @RequestMapping("/graphql")
    public String mainEntry() {
        return "graphql";
    }
}

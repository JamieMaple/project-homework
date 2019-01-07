package com.maple.helper;

import java.util.Base64;

public class Convert {
    public static String toBase64String(byte[] bytes) {
        return Base64.getEncoder().encodeToString(bytes);
    }
    
    public static byte[] fromBase64String(String str) {
        return Base64.getDecoder().decode(str);
    }
}

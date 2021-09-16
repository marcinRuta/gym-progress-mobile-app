package com.example.gymtracker.DTO;

public class ResponseData {

    private String responseDescription;

    public ResponseData(String response) {
        responseDescription = response;
    }

    public String getResponseDescription() {
        return responseDescription;
    }

    public void setResponseDescription(String responseDescription) {
        this.responseDescription = responseDescription;
    }
}

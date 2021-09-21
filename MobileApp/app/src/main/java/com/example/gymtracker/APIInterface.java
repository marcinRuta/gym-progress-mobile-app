package com.example.gymtracker;

import com.example.gymtracker.DTO.LogData;
import com.example.gymtracker.DTO.ResponseData;
import com.example.gymtracker.DTO.UserDetails;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.Headers;
import retrofit2.http.POST;

public interface APIInterface {

    @POST("ClientApi/loginUser")
    Call<ResponseData> logUser(@Header("username") String username,
                               @Header("password") String password);


    @Headers({"accept: text/json","Content-Type: application/json"})
    @POST("ClientApi/registerUser")
    Call<ResponseData> registerUser(@Body LogData logData);


    @Headers({"accept: text/json","Content-Type: application/json"})
    @POST("ClientApi/addUserDetails")
    Call<ResponseData> addDetails(@Header("username") String username,
                                  @Header("password") String password, @Body UserDetails details);


    @Headers({"accept: text/json","Content-Type: application/json"})
    @GET("ClientApi/UserDetails")
    Call<UserDetails> getDetails(@Header("username") String username,
                               @Header("password") String password);
}

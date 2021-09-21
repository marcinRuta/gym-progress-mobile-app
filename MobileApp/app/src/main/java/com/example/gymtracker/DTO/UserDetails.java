package com.example.gymtracker.DTO;

public class UserDetails {

    public String name;
    public String surname;
    public String email;
    public String telephoneNumber;


    public UserDetails(String name, String surname, String email, String telephoneNumber) {
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.telephoneNumber = telephoneNumber;
    }
}

package com.example.gymtracker.DTO;

public class UserDetails {

    public String Name;
    public String Surname;
    public String Email;
    public String TelephoneNumber;


    public UserDetails(String name, String surname, String email, String telephoneNumber) {
        Name = name;
        Surname = surname;
        Email = email;
        TelephoneNumber = telephoneNumber;
    }
}

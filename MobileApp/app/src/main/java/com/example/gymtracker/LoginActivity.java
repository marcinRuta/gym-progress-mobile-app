package com.example.gymtracker;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import androidx.appcompat.app.AppCompatActivity;

import com.example.gymtracker.DTO.LogData;
import com.example.gymtracker.DTO.ResponseData;


public class LoginActivity extends AppCompatActivity {
    EditText mTextUsername;
    EditText mTextPassword;
    Button mButtonLogin;
    TextView mTextViewRegister;
    String Tag ="loginActivity";
    APIInterface apiInterface;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        apiInterface = APIClient.getClient().create(APIInterface.class);
        mTextUsername = (EditText)findViewById(R.id.edittext_username);
        mTextPassword = (EditText)findViewById(R.id.edittext_password);
        mButtonLogin = (Button)findViewById(R.id.button_login);
        mButtonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String username = mTextUsername.getText().toString();
                String password = mTextPassword.getText().toString();
                if(validateLogin(username, password)){

                    doLogin(username, password);
                }



                //Intent homeIntent = new Intent (LoginActivity.this, MainActivity.class);
               // startActivity(homeIntent);


            }
        });
        mTextViewRegister = (TextView)findViewById(R.id.textview_register);
        mTextViewRegister.setOnClickListener (new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent registerIntent = new Intent (LoginActivity.this, RegisterActivity.class);
                startActivity(registerIntent);
            }
        });
    }

    private boolean validateLogin(String username, String password){
        if(username == null || username.trim().length() == 0){
            Toast.makeText(this, "Username is required", Toast.LENGTH_SHORT).show();

            return false;

        }
        if(password == null || password.trim().length() == 0){
            Toast.makeText(this, "Password is required", Toast.LENGTH_SHORT).show();

            return false;
        }

        return true;
    }

    private void doLogin(final String username,final String password){


        Call call = apiInterface.logUser(username, password);

        call.enqueue(new Callback() {
            @Override
            public void onResponse(Call call, Response response) {
                Log.d(Tag,"zalogowano api");
                if(response.isSuccessful()){
                    ResponseData resObj = (ResponseData) response.body();
                    Log.d(Tag,"zalogowano api");

                    if(resObj.getResponseDescription().equals("Invalid combination")){

                        Toast.makeText(LoginActivity.this, "The username or password is incorrect", Toast.LENGTH_SHORT).show();

                    } else {
                        Log.d(Tag,"zalogowano api");
                        Intent intent = new Intent(LoginActivity.this, MainActivity.class);

                        intent.putExtra("username",username);
                        intent.putExtra("password",password);
                        startActivity(intent);

                    }
                } else {
                    Toast.makeText(LoginActivity.this, "Error! Please try again!", Toast.LENGTH_SHORT).show();
                    Log.d(Tag,"zalogowano api");
                }
            }

            @Override
            public void onFailure(Call call, Throwable t) {
                Toast.makeText(LoginActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
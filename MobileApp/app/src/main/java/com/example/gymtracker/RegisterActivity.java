package com.example.gymtracker;

import android.content.Intent;
import android.os.Bundle;
import android.provider.Settings;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;


import com.example.gymtracker.DTO.LogData;
import com.example.gymtracker.DTO.ResponseData;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RegisterActivity extends AppCompatActivity {

    EditText mTextUsername;
    EditText mTextPassword;
    EditText mTextCnfPassword;
    Button mButtonRegister;
    TextView mTextViewLogin;
    APIInterface apiInterface;
    String Tag ="registerctivity";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        apiInterface = APIClient.getClient().create(APIInterface.class);
        mTextUsername = (EditText) findViewById(R.id.edittext_username);
        mTextPassword = (EditText) findViewById(R.id.edittext_password);
        mTextCnfPassword = (EditText) findViewById(R.id.edittext_cnf_password);
        mButtonRegister = (Button) findViewById(R.id.button_register);

        mTextViewLogin = (TextView) findViewById(R.id.textview_login);
        mTextViewLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent LoginIntent = new Intent(RegisterActivity.this, LoginActivity.class);
                startActivity(LoginIntent);
            }
        });

        mButtonRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String user = mTextUsername.getText().toString().trim();
                String pwd = mTextPassword.getText().toString().trim();
                String cnf_pwd = mTextCnfPassword.getText().toString().trim();

                if(validateRegister(user, pwd, cnf_pwd)){

                 doRegister(user, pwd);
                 }
            }
        });
    }

    private boolean validateRegister(String username, String password, String cnfpassword) {
        if (username == null || username.trim().length() == 0) {
            Toast.makeText(this, "Username is required", Toast.LENGTH_SHORT).show();
            return false;
        }
        if (password == null || password.trim().length() == 0) {
            Toast.makeText(this, "Password is required", Toast.LENGTH_SHORT).show();
            return false;
        }
        if (cnfpassword == null || cnfpassword.trim().length() == 0) {
            Toast.makeText(this, "Confirmed password is required", Toast.LENGTH_SHORT).show();
            return false;
        }
        if (!cnfpassword.trim().equals(password.trim())) {
            Toast.makeText(this, "Confirmed password and password are not the same", Toast.LENGTH_SHORT).show();
            return false;
        }
        return true;
    }

    private void doRegister(final String username, final String password) {


        LogData regData= new LogData(username, password);

        Call call = apiInterface.registerUser(regData);

        call.enqueue(new Callback() {
            @Override
            public void onResponse(Call call, Response response) {
                Log.d(Tag,"wysłano i okej"+response.code());

                if (response.isSuccessful()) {


                    ResponseData resObj = (ResponseData) response.body();

                    switch (resObj.getResponseDescription()) {
                        case ("Succesufully registered"):
                            Toast.makeText(RegisterActivity.this, "U have registered correctly", Toast.LENGTH_SHORT).show();
                            Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                            startActivity(intent);
                            break;
                        case ("Already registered"):
                            Toast.makeText(RegisterActivity.this, "That username is already taken", Toast.LENGTH_SHORT).show();
                            break;
                    }

                } else {
                    Log.d(Tag," sie");
                    Toast.makeText(RegisterActivity.this, "Error! Please try again!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call call, Throwable t) {
                Toast.makeText(RegisterActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
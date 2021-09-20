package com.example.gymtracker;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.gymtracker.DTO.ResponseData;
import com.example.gymtracker.DTO.UserDetails;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProfileActivity  extends AppCompatActivity {
    EditText mTextName;
    EditText mTextSurname;
    EditText mTextEmail;
    EditText mTextPhone;
    Button mButtonBack;
    Button mButtonEdit;
    TextView mTextViewRegister;
    String Tag ="ProfileActivity";
    APIInterface apiInterface;
    private String mUsername = "Test";
    private String mPassword = "Test";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);
        apiInterface = APIClient.getClient().create(APIInterface.class);
        mTextName = (EditText)findViewById(R.id.editTextName);
        mTextSurname = (EditText)findViewById(R.id.editTextSurname);
        mTextEmail = (EditText)findViewById(R.id.editTextEmailAddress);
        mTextPhone = (EditText)findViewById(R.id.editTextPhone);
        mButtonBack = (Button)findViewById(R.id.button_back);
        mButtonEdit = (Button)findViewById(R.id.button_edit);


        Intent intent = getIntent();
        Bundle bundle = intent.getExtras();
        if (bundle != null) {
            mPassword = (String) bundle.get("password");
            mUsername = (String) bundle.get("username");
        }

        mButtonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent mainIntent = new Intent (ProfileActivity.this, MainActivity.class);
                startActivity(mainIntent);

            }
        });

        mButtonEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(ValidateEdit()){
                    EditDetails();
                }
            }
        });

    }
    private  boolean ValidateEdit(){

        if(mTextName.getText().toString()==null || mTextSurname.getText().toString()==null || mTextEmail.getText().toString()==null || mTextPhone.getText().toString()==null){
            return false;
        }

        return  true;
    }


    private void EditDetails(){

        UserDetails Details= new UserDetails(mTextName.getText().toString().trim() ,  mTextSurname.getText().toString().trim(), mTextEmail.getText().toString().trim(),mTextPhone.getText().toString().trim());
        Call call =apiInterface.addDetails(mUsername, mPassword, Details);
        call.enqueue(new Callback() {
            @Override
            public void onResponse(Call call, Response response) {
                if(response.isSuccessful()){
                    ResponseData resObj = (ResponseData) response.body();
                    Log.d(Tag,"zalogowano api");

                    if(resObj.getResponseDescription().equals("Wrong credentials")){

                        Toast.makeText(ProfileActivity.this, "The username or password is incorrect", Toast.LENGTH_SHORT).show();

                    }
                    else if (resObj.getResponseDescription().equals("Succesufully updated details")) {
                        Log.d(Tag,"zalogowano api");
                    }
                    else {
                        Toast.makeText(ProfileActivity.this, "Error", Toast.LENGTH_SHORT).show();
                    }
                }
                else {
                    Toast.makeText(ProfileActivity.this, "Error! Please try again!", Toast.LENGTH_SHORT).show();

                }
            }

            @Override
            public void onFailure(Call call, Throwable t) {
                Toast.makeText(ProfileActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}

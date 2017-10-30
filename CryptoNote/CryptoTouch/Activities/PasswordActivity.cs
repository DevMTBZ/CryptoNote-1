﻿using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Android.Graphics;

using CryptoNote.Security;
using CryptoNote.Model;

namespace CryptoNote.Activities
{
    [Activity(Label = "CryptoNote", MainLauncher = true, 
              Icon = "@drawable/fingerprint",
              Theme = "@style/AppTheme",
              ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class PasswordActivity : AppCompatActivity
    {
        private Button _submitButton;
        private EditText _passwordEditText;
        private EditText _passwordConfirmEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SecurityProvider.InitializeSecuritySystem();
            Settings.Load(this);
            this.Resources.Configuration.SetLocale(new Java.Util.Locale(Settings.Language));
            this.Resources.UpdateConfiguration(this.Resources.Configuration, this.Resources.DisplayMetrics);

            if (SecurityProvider.KeyExists())
                OpenAuthorizationPage();
            this.SetContentView(Resource.Layout.PasswordPage);
            InitializeViews();
        }

        protected override void OnStart()
        {
            base.OnStart();
            FindViewById<TextView>(Resource.Id.passwordPageHintTextView).Text = Resources.GetString(Resource.String.WelcomePassword);
            _submitButton.Text = Resources.GetString(Resource.String.SubmitButton);
        }

        private void InitializeViews()
        {
            _submitButton = FindViewById<Button>(Resource.Id.ButtonSubmitPassword);
            _passwordEditText = FindViewById<EditText>(Resource.Id.RegisterPassword);
            _passwordConfirmEditText = FindViewById<EditText>(Resource.Id.RegisterPasswordConfirm);

            _submitButton.Click += (object sender, EventArgs e) => SubmitPassword();
            _passwordEditText.RequestFocus();
            Typeface font = Typeface.CreateFromAsset(Assets, "fonts/BROADW.ttf");
            FindViewById<TextView>(Resource.Id.passwordPageTitle).Typeface = font;
        }

        private void SubmitPassword()
        {
            if (_passwordEditText.Text != string.Empty)
            {
                if (_passwordEditText.Text == _passwordConfirmEditText.Text)
                {
                    SecurityProvider.InitializeUser(_passwordEditText.Text, this);
                    Intent intent = new Intent(this, typeof(MainPageActivity));
                    StartActivity(intent);
                }
                else Toast.MakeText(this, this.Resources.GetString(Resource.String.PasswordMissmatchError), ToastLength.Long).Show();
            }
            else Toast.MakeText(this, this.Resources.GetString(Resource.String.EmptyPasswordError), ToastLength.Long).Show();
        }

        private void OpenAuthorizationPage()
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }
    }
}
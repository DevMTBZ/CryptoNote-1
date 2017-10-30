using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;

using CryptoNote.Adapters;

namespace CryptoNote.Activities
{
    [Activity(Label = "MainPageActivity", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainPageActivity : AppCompatActivity
    {
        public static ViewPager Navigation { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainPage);
            Navigation = FindViewById<ViewPager>(Resource.Id.viewpager);
            Navigation.Adapter = new ViewPagerAdapter(this.SupportFragmentManager, this);
            FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabs).SetupWithViewPager(Navigation);
            FindViewById<ImageButton>(Resource.Id.settingsButton).Click += (object sender, EventArgs e) 
                                                                   => StartActivity(new Intent(this, typeof(SettingsActivity)));
        }

        public override void OnBackPressed()
        {
            (Navigation.Adapter as ViewPagerAdapter).HandleOnBackPressed(base.OnBackPressed);
        }
    }
}
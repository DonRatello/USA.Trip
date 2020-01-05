﻿using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace USA.Trip
{
    [Activity(Label = "@string/app_name", 
        Theme = "@style/AppTheme.NoActionBar", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.Orientation, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        ViewFlipper viewFlipper;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            viewFlipper = FindViewById<ViewFlipper>(Resource.Id.viewFlipper);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.nav_dashboard:
                    viewFlipper.DisplayedChild = Constants.Views.Dashboard;
                    break;
                case Resource.Id.nav_flight_nyc:
                    viewFlipper.DisplayedChild = Constants.Views.FlightNyc;
                    break;
                case Resource.Id.nav_flight_krk:
                    viewFlipper.DisplayedChild = Constants.Views.FlightKrk;
                    break;
                case Resource.Id.nav_budget_summary:
                    viewFlipper.DisplayedChild = Constants.Views.BudgetSummary;
                    break;
                case Resource.Id.nav_budget_income:
                    viewFlipper.DisplayedChild = Constants.Views.BudgetIncome;
                    break;
                case Resource.Id.nav_budget_expenses:
                    viewFlipper.DisplayedChild = Constants.Views.BudgetExpenses;
                    break;
                case Resource.Id.nav_others_hotel:
                    viewFlipper.DisplayedChild = Constants.Views.OthersHotel;
                    break;
                case Resource.Id.nav_others_subway:
                    viewFlipper.DisplayedChild = Constants.Views.OthersSubway;
                    break;
                default:
                    Toast.MakeText(Application.Context, "View not found", ToastLength.Short).Show();
                    break;
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}


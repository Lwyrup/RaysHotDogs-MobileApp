﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RaysHotDogs.Droid
{
    [Activity(Label = "Ray's Hot Dogs", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        Button orderButton;
        Button cartButton;
        Button aboutButton;
        Button mapButton;
        Button takePictureButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
        }

        void FindViews()
        {
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cartButton.Click += CartButton_Click;
            aboutButton.Click += AboutButton_Click;
            mapButton.Click += MapButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
        }

        void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }

        void CartButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RayMapActivity));
            StartActivity(intent);
        }

        void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }
    }
}

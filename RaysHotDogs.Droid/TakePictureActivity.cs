using System;
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
    [Activity(Label = "Take a picture with Ray")]
    public class TakePictureActivity : Activity
    {
        ImageView rayPictureImageView;
        Button takePictureButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TakePictureView);

            FindViews();
            HandleEvents();
        }

		private void FindViews()
		{
			rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
			takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
		}

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        void TakePictureButton_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Droid.Utility;

namespace RaysHotDogs.Droid
{
    [Activity(Label = "Hot Dog Detail")]
    public class HotDogDetailActivity : Activity
    {
        ImageView hotDogImageView;
        TextView hotDogNameTextView;
        TextView shortDescriptionTextView;
        TextView descriptionTextView;
        TextView priceTextView;
        EditText amountEditText;
        Button cancelButton;
        Button orderButton;

        HotDog selectedHotDog;
        HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogDetailView);

            dataService = new HotDogDataService();
            var selectedHotDogId = Intent.Extras.GetInt("selectedHotDogId");
            selectedHotDog = dataService.getHotDogById(selectedHotDogId);

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            hotDogNameTextView.Text = selectedHotDog.Name;
            shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
            descriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = "Price: " + String.Format("{0:0.00}", selectedHotDog.Price);

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg");
            hotDogImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;

            cancelButton.Click += CancelButton_Click;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(amountEditText.Text);

            var intent = new Intent();
            intent.PutExtra("selectedHotDogId", selectedHotDog.HotDogId);
            intent.PutExtra("amount", amount);

            SetResult(Result.Ok, intent);
            this.Finish();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}

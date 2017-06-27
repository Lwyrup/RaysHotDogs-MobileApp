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
using RaysHotDogs.Droid.Adapters;

namespace RaysHotDogs.Droid
{
    [Activity(Label = "HotDogMenuActivity", MainLauncher = true)]
    public class HotDogMenuActivity : Activity
    {
        ListView hotDogListView;
        List<HotDog> allHotDogs;
        HotDogDataService hotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogMenuView);

            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);

            hotDogDataService = new HotDogDataService();
            allHotDogs = hotDogDataService.getAllHotDogs();

            hotDogListView.Adapter = new HotDogListAdapter(this, allHotDogs);
            hotDogListView.FastScrollEnabled = true;
        }
    }
}

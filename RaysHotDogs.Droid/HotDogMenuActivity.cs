using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Droid.Adapters;
using RaysHotDogs.Droid.Fragments;

namespace RaysHotDogs.Droid
{
    [Activity(Label = "HotDogMenuActivity")]
    public class HotDogMenuActivity : Activity
    {
        ListView hotDogListView;
        List<HotDog> allHotDogs;
        HotDogDataService hotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            var colorDrawable = new ColorDrawable(Color.LightGray);
            ActionBar.SetStackedBackgroundDrawable(colorDrawable);

            addTab("Favorites", Resource.Drawable.homeimg, new FavoriteHotDogFragment());
            addTab("Meat Lovers", Resource.Drawable.meatlovericon, new MeatLoversFragment());
            addTab("Veggie Lovers", Resource.Drawable.homeimg, new VeggieLoversFragment());

            SetContentView(Resource.Layout.HotDogMenuView);
        }

        void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = allHotDogs[e.Position];
            var intent = new Intent(this, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedHotDog = allHotDogs[data.GetIntExtra("selectedHotDogId", 1)];

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(String.Format("You've added {0} order(s) of the {1} to your cart.", data.GetIntExtra("amount", 1), selectedHotDog.Name));
                dialog.Show();
            }
        }

        private void addTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) 
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) 
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}

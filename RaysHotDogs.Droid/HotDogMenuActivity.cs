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
    [Activity(Label = "Menu")]
    public class HotDogMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            var colorDrawable = new ColorDrawable(Color.DarkGray);
            ActionBar.SetStackedBackgroundDrawable(colorDrawable);

            AddTab("Favorites", Resource.Drawable.favoriteicon, new FavoriteHotDogFragment());
            AddTab("Meat Lovers", Resource.Drawable.meatlovericon, new MeatLoversFragment());
            AddTab("Veggie Lovers", Resource.Drawable.veggielovericon, new VeggieLoversFragment());

            SetContentView(Resource.Layout.HotDogMenuView);
        }

        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) 
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
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

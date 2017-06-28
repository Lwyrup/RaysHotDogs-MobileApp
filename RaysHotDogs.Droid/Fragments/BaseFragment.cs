using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected HotDogDataService hotDogDataService;
        protected List<HotDog> hotDogs;

        public BaseFragment() 
        {
            hotDogDataService = new HotDogDataService();
        }

        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }

		protected void HandleEvents()
		{
			listView.ItemClick += ListView_ItemClick;
		}
        
        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = hotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

            StartActivityForResult(intent, 100);
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok && requestCode == 100)
			{
                var selectedHotDog = hotDogDataService.getHotDogById(data.GetIntExtra("selectedHotDogId", 1));

				var dialog = new AlertDialog.Builder(this.Context);
				dialog.SetTitle("Confirmation");
				dialog.SetMessage(String.Format("You've added {0} order(s) of the {1} to your cart.", data.GetIntExtra("amount", 1), selectedHotDog.Name));
				dialog.Show();
			}
        }
    }
}

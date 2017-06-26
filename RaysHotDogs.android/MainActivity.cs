using Android.App;
using Android.Widget;
using Android.OS;
using RaysHotDogs.android.Resources;

namespace RaysHotDogs.android
{
    [Activity(Label = "Ray's Hot Dogs", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
        }
    }
}


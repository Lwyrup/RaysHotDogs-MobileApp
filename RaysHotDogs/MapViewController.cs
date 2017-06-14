using Foundation;
using System;
using UIKit;
using Xamarin.Media;
using MapKit;
using CoreLocation;

namespace RaysHotDogs
{
    public partial class MapViewController : UIViewController
    {
        MKMapView mapView;
        CLLocationManager locationManager = new CLLocationManager();

        public MapViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            mapView = new MKMapView(View.Bounds)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions,
                MapType = MKMapType.Standard
            };
            View.AddSubview(mapView);

            double latitude = 50.846732;
            double longitude = 4.352413;

            var raysLocation = new CLLocationCoordinate2D(latitude, longitude);
            var zoomRegion = MKCoordinateRegion.FromDistance(raysLocation, 2000, 2000);

            mapView.CenterCoordinate = raysLocation;
            mapView.Region = zoomRegion;

            locationManager.RequestWhenInUseAuthorization();
            mapView.ShowsUserLocation = true;

            mapView.AddAnnotation( new MKPointAnnotation(){
                Title = "Ray's Hot Dogs",
                Coordinate = new CLLocationCoordinate2D( latitude, longitude)
            });
        }
    }
}
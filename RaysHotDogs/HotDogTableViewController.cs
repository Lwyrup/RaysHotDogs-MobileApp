using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core.Service;
using RaysHotDogs.DataSource;

namespace RaysHotDogs
{
    public partial class HotDogTableViewController : UITableViewController
    {
        HotDogDataService dataService = new HotDogDataService();
		public HotDogTableViewController(IntPtr handle) : base (handle)
        {
		}

        public override void ViewDidLoad()
        {
            var hotDogs = dataService.getAllHotDogs();
            var datasource = new HotDogDataSource(hotDogs, this);
            TableView.Source = datasource;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "HotDogDetailSegue")
            {
                var hotDogDetailViewController = segue.DestinationViewController as HotDogDetailsViewController;
                if (hotDogDetailViewController != null)
                {
                    var source = TableView.Source as HotDogDataSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    hotDogDetailViewController.SelectedHotDog = item;
                }
            }
        }
    }
}
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
        public HotDogTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            var hotDogs = dataService.getAllHotDogs();
            var datasource = new HotDogDataSource(hotDogs, this);
            TableView.Source = datasource;
        }
    }
}
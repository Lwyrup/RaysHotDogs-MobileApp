using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.DataSource;

namespace RaysHotDogs
{
    public partial class MeatLoversTableViewController : HotDogTableViewController
    {
        HotDogDataService dataService = new HotDogDataService();
        public MeatLoversTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var meatLovers = dataService.GetMeatLoversHotDogs();
            TableView.Source = new HotDogDataSource(meatLovers, this);
        }
    }
}
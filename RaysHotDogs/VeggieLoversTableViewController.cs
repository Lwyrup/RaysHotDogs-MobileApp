using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.DataSource;

namespace RaysHotDogs
{
    public partial class VeggieLoversTableViewController : HotDogTableViewController
    {
        HotDogDataService dataService = new HotDogDataService();
        public VeggieLoversTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var veggieLovers = dataService.GetVeggieLoversHotDogs();
            TableView.Source = new HotDogDataSource(veggieLovers, this);
        }
    }
}
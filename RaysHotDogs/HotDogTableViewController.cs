using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core.Service;
using RaysHotDogs.DataSource;
using RaysHotDogs.Core.Model;

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
            base.ViewDidLoad();
            var hotDogs = dataService.getAllHotDogs();
            var datasource = new HotDogDataSource(hotDogs, this);
            TableView.Source = datasource;
        }

        public async void HotDogSelected(HotDog selectedHotDog)
        {
            HotDogDetailsViewController hotDogDetailsViewController =
                this.Storyboard.InstantiateViewController("HotDogDetailsViewController") as HotDogDetailsViewController;
            if (hotDogDetailsViewController != null)
            {
                hotDogDetailsViewController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;
                hotDogDetailsViewController.SelectedHotDog = selectedHotDog;

                await PresentViewControllerAsync(hotDogDetailsViewController, true);
            }
        }
    }
}
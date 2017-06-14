using System;
using RaysHotDogs.Core.Service;
using RaysHotDogs.DataSource;

namespace RaysHotDogs
{
    public partial class FavoriteTableViewController : HotDogTableViewController
    {
        HotDogDataService dataService = new HotDogDataService();
        public FavoriteTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var favorites = dataService.GetFavoriteHotDogs();
            TableView.Source = new HotDogDataSource(favorites, this);
        }
    }
}
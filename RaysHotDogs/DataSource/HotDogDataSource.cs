using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs.DataSource
{
    public class HotDogDataSource: UITableViewSource
    {
        private List<HotDog> hotDogs;
        private UITableViewController tableController;
        NSString cellIdentifier = new NSString("HotDogCell");

        public HotDogDataSource(List<HotDog> hotDogs, UITableViewController callingController)
        {
            this.hotDogs = hotDogs;
            this.tableController = callingController;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return hotDogs.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            HotDogListCell cell = tableView.DequeueReusableCell(cellIdentifier) as HotDogListCell;

            if (cell == null)
            {
                cell = new HotDogListCell(cellIdentifier);
            }

            cell.UpdateCell(
                hotDogs[indexPath.Row].Name, 
                hotDogs[indexPath.Row].Price.ToString(), 
                UIImage.FromFile("Images/hotdog" + hotDogs[indexPath.Row].HotDogId + ".jpg")
            );

            return cell;
        }

        public HotDog GetItem(int id)
        {
            return hotDogs[id];
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableController.PerformSegue("HotDogDetailSegue",tableController);
        }
    }
}

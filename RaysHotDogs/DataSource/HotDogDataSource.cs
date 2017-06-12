using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.DataSource
{
    public class HotDogDataSource: UITableViewSource
    {
        private List<HotDog> hotDogs;
        NSString cellIdentifier = new NSString("HotDogCell");

        public HotDogDataSource(List<HotDog> hotDogs, UITableViewController callingController)
        {
            this.hotDogs = hotDogs;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return hotDogs.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            HotDogListCell cell = tableView.DequeueReusableCell(cellIdentifier) as HotDogListCell;

            if (cell == null)
               cell = new HotDogListCell(cellIdentifier);

            cell.UpdateCell(
                hotDogs[indexPath.Row].Name, 
                hotDogs[indexPath.Row].Price.ToString(), 
                UIImage.FromFile("Images/" + hotDogs[indexPath.Row].HotDogId + ".jpg")
            );

            return cell;
        }
    }
}

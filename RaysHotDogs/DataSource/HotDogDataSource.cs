using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.DataSource
{
    public class HotDogDataSource: UITableViewSource
    {
        List<HotDog> hotDogs;
        HotDogTableViewController callingController;
        NSString cellIdentifier = new NSString("HotDogCell");

        public HotDogDataSource(List<HotDog> hotDogs, HotDogTableViewController callingController)
        {
            this.hotDogs = hotDogs;
            this.callingController = callingController;
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
                String.Format("${0:0.00}", hotDogs[indexPath.Row].Price), 
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
            var selectedHotDog = hotDogs[indexPath.Row];
            callingController.HotDogSelected(selectedHotDog);
            tableView.DeselectRow(indexPath, true);
        }
    }
}

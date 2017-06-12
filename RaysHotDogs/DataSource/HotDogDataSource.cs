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
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            }

            var hotDog = hotDogs[indexPath.Row];
            cell.TextLabel.Text = hotDog.Name;
            cell.ImageView.Image = UIImage.FromFile("Images/hotdog" + hotDog.HotDogId + ".jpg");

            return cell;
        }
    }
}

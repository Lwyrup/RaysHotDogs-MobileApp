using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs
{
    public partial class HotDogDetailsViewController : UIViewController
    {
        public HotDog SelectedHotDog
        {
            set;
            get;
        }

        public HotDogDetailsViewController (IntPtr handle) : base (handle)
        {
            HotDogDataService hotDogDataService = new HotDogDataService();
            SelectedHotDog = hotDogDataService.getHotDogById(3);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DatabindUI();

            AddToCartButton.TouchUpInside += (sender, e) => 
            {
                UIAlertView message = new UIAlertView() { Title = "Ray's Hot Dogs", Message = "Hot dog(s) added to cart." };
                message.AddButton("OK");
                message.Show();
                DismissViewController(true,() => {});
            };

            CancelButton.TouchUpInside += (sender, e) => 
            {
                DismissViewController(true, () => { });
            };
        }

        private void DatabindUI()
        {
            UIImage img = UIImage.FromFile("Images/" + SelectedHotDog.ImagePath + ".jpg");
            HotDogImageView.Image = img;
            NameLabel.Text = SelectedHotDog.Name;
            ShortDescriptionLabel.Text = SelectedHotDog.ShortDescription;
            LongDescriptionText.Text = SelectedHotDog.Description;
            PriceLabel.Text = "$" + SelectedHotDog.Price.ToString();
        }
    }
}
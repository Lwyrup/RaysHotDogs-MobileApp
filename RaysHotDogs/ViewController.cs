using System;
using System.CodeDom.Compiler;
using Foundation;
using UIKit;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs
{
    public partial class ViewController : UIViewController
    {

		public HotDog SelectedHotDog
		{
			get;
			set;
		}

        protected ViewController(IntPtr handle) : base(handle)
        {
			HotDogDataService hotDogDataService = new HotDogDataService();
            SelectedHotDog = hotDogDataService.getHotDogById(1);
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DatabindUI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void DatabindUI()
        {
			UIImage img = UIImage.FromFile("Images/" + SelectedHotDog.ImagePath + ".jpg");
			HotDogImageView.Image = img;
			NameLabel.Text = SelectedHotDog.Name;
		}
	}
}
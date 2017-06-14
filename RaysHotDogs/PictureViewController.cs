using Foundation;
using System;
using UIKit;
using Xamarin.Media;
using System.Threading.Tasks;

namespace RaysHotDogs
{
    public partial class PictureViewController : UIViewController
    {
        MediaPicker mediaPicker = new MediaPicker();
        TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        UIAlertView alertView;
        MediaPickerController mediaPickerController;

        public PictureViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TakePictureButton.TouchUpInside += (sender, e) => 
            {
                if (!mediaPicker.IsCameraAvailable)
                {
                    alertView = new UIAlertView()
                    {
                        Title = "Ray's Hot Dogs",
                        Message = "Sadly, you cannot take a picture"
                    };
                    alertView.AddButton("Ok");
                    alertView.Show();

                    return;
                }

                mediaPickerController = mediaPicker.GetTakePhotoUI( new StoreCameraMediaOptions()
                {
                    Name = "hotdogselfie.jpg",
                    Directory = "RaysHotDogSelfies"
                });

                PresentViewController( mediaPickerController, true, null);
                mediaPickerController.GetResultAsync().ContinueWith( t => 
                {
                    HotDogImage.Image = UIImage.FromFile(t.Result.Path);
                    DismissViewController(true, null);
                }, uiScheduler);
            };
        }
    }
}
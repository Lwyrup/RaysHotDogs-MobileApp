using Foundation;
using System;
using UIKit;
using Social;

namespace RaysHotDogs
{
    public partial class TweetViewController : UIViewController
    {
        SLComposeViewController sLComposeViewController;

        public TweetViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SendTweetButton.TouchUpInside += (sender, e) => 
            {
                if (SLComposeViewController.IsAvailable( SLServiceKind.Twitter))
                {
                    sLComposeViewController = SLComposeViewController.FromService(SLServiceKind.Twitter);
                    sLComposeViewController.SetInitialText(TweetText.Text);
                    sLComposeViewController.CompletionHandler += (result) => 
                    {
                        InvokeOnMainThread(() =>
                        {
                            DismissViewController(true, null);
                            UIAlertView messageBox = new UIAlertView("Ray's Hot Dogs", "Tweet sent", null, "Ok");
                            messageBox.Show();
                        });
                    };
                    PresentViewController( sLComposeViewController, true, null);
                }
                else
                {
                    UIAlertView messageBox = new UIAlertView("Ray's Hot Dogs", "Twitter unavailable", null, "Ok");
                    messageBox.Show();
                }
            };
        }
    }
}
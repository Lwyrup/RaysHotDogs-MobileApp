// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RaysHotDogs
{
    [Register ("PictureViewController")]
    partial class PictureViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HotDogImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TakePictureButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HotDogImage != null) {
                HotDogImage.Dispose ();
                HotDogImage = null;
            }

            if (TakePictureButton != null) {
                TakePictureButton.Dispose ();
                TakePictureButton = null;
            }
        }
    }
}
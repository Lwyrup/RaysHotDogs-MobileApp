using System;
using System.Net;
using Android.Graphics;

namespace RaysHotDogs.Droid.Utility
{
    public class ImageHelper
    {
        public ImageHelper()
        {
        }

        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }

        public static Bitmap GetImageBitmapFromFilePath(string fileName, int width, int height)
        {
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            int outputHeight = options.OutHeight;
            int outputWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outputHeight > height || outputWidth > width)
            {
                inSampleSize = outputWidth > outputHeight ? outputHeight / height : outputWidth / width;
            }

            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }
}

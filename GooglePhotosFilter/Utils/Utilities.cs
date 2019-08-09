using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Utils
{
    public class Utilities
    {
        private const int MAX_PICTURE_WIDTH = 220;
        private const int MAX_PICTURE_HEIGHT = 164;

        public static Bitmap GetThumbnails(string imageUrl)
        {
            Bitmap bmpPhoto = new Bitmap(1, 1);

            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();

                Bitmap bmpPhotoFull = new Bitmap(responseStream);

                Image image = bmpPhotoFull.GetThumbnailImage(bmpPhotoFull.Width / 2, bmpPhotoFull.Height / 2, () => false, IntPtr.Zero);

                bmpPhoto = new Bitmap(image);
            }
            catch (Exception ex)
            {

            }

            return bmpPhoto;
        }

        public static Bitmap GetBmpFromGoogleUrl(string imageUrl)
        {
            Bitmap bmpPhoto = new Bitmap(1, 1);

            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();

                Bitmap bmpPhotoFull = new Bitmap(responseStream);

                double ratio = (double)bmpPhotoFull.Width / MAX_PICTURE_WIDTH;
                double newHeight = bmpPhotoFull.Height / ratio;

                if (newHeight < MAX_PICTURE_HEIGHT)
                    newHeight = MAX_PICTURE_HEIGHT;

                Image image = bmpPhotoFull.GetThumbnailImage(MAX_PICTURE_WIDTH, (int)newHeight, () => false, IntPtr.Zero);

                bmpPhoto = new Bitmap(image);
            }
            catch (Exception ex)
            {

            }

            return bmpPhoto;
        }
    }
}

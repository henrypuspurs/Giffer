using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using AnimatedGif;

namespace Giffer
{
    public class ImgConvert
    {
        public void ImgToGif(string[] files, string[] imgOptions)
        {
            int i = 0;
            int imax = files.Length;
            string filename = imgOptions[0];
            string destpath = imgOptions[4];
            int qualityR = int.Parse(imgOptions[2]);
            int framerate = int.Parse(imgOptions[3]);
            Console.WriteLine("Running");

            // Create(OutputFilepath, Framerate)
            using (var gif = AnimatedGif.AnimatedGif.Create($"{destpath}\\{filename}", framerate))
            {
                foreach (string file in files)
                {
                    i++;
                    var img = Image.FromFile(file);
                    if (qualityR != 1)
                    {
                        int imgW = img.Width / qualityR;
                        int imgH = img.Height / qualityR;
                        var resized = ResizeImage(img, imgW, imgH);
                        gif.AddFrame(resized, delay: -1, quality: GifQuality.Bit8);
                    }
                    else
                    {
                        gif.AddFrame(img, delay: -1, quality: GifQuality.Bit8);
                    }
                    Console.Write($"\r Processing image {i} of {imax}");
                }
            }
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Done");

        }

        // *** Thanks to answers on https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
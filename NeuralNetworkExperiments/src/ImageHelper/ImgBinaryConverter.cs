using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkExperiments.ImageHelper
{
    public static class ImgBinaryConverter
    {
        private static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height)
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

        public static double[,] ConvertTo1D(string path)
        {
            var image1d = new double[1, 32 * 32];
            using (var image = Image.FromFile(path))
            {
                using (var bitmap = ResizeImage(image, 32, 32))
                {
                    using (var grayscale = MakeGrayscale3(bitmap))
                    {
                        // Здесь начинается преобразование в double[1,32x32]
                        //grayscale.Save(path + "_grayscaled.bmp");

                        var indx = 0;
                        for (int y = 0; y < 32; y++)
                        {
                            for (int x = 0; x < 32; x++)
                            {
                                var brightness = grayscale.GetPixel(x, y).GetBrightness();
                                image1d[0, indx++] = brightness;
                            }
                        }
                    }
                }
            }
            return image1d;
        }

        private static List<Tuple<int, double[,]>> _dataFiles;
        public static List<Tuple<int, double[,]>> UnpackDataFiles(string path)
        {
            _dataFiles = new List<Tuple<int, double[,]>>();

            ProcessDirectory(path);

            return _dataFiles;
        }

        private static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (Path.GetExtension(fileName) == ".data")
                    ProcessFile(fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        private static void ProcessFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var bf = new BinaryFormatter();
                var classify = (int)bf.Deserialize(stream);
                var image = (double[,])bf.Deserialize(stream);
                _dataFiles.Add(new Tuple<int, double[,]>(classify, image));
                Console.WriteLine("Unpacked file '{0}'; class: {1}", fileName, classify);
            }
        }
    }
}

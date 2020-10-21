using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBalance
{
    public abstract class Algorithms
    {
        public static Bitmap GrayWorld(Image img)
        {
            D_Color means = Means(img);
            var pixel_count = img.Width * img.Height;
            double r_factor = means.g / means.r;
            double b_factor = means.g / means.b;

            var original = new Bitmap(img);
            var ret = new Bitmap(img.Width, img.Height);

            for(int x = 0; x < img.Width; x++)
            {
                for(int y = 0; y < img.Height; y++)
                {
                    ret.SetPixel(x, y, Color.FromArgb(
                        Math.Max(0, Math.Min(255, (int)(original.GetPixel(x, y).R / r_factor))),
                        original.GetPixel(x, y).G,
                        Math.Max(0, Math.Min(255, (int)(original.GetPixel(x, y).B / b_factor)))));
                }
            }

            return ret;
        }

        public static Bitmap WhitePatch(Image img, double green_scale)
        {
            D_Color maxes = Maxes(img);
            D_Color means = Means(img);
            var pixel_count = img.Width * img.Height;
            // equation right side

            // first equation
            double g_avg_x_dimensions = means.g * pixel_count;

            // equation left side

            // first equation
            double r_quadratic_sum = QuadraticSum(img, 0);
            double b_quadratic_sum = QuadraticSum(img, 2);
            double r_sum = Sum(img, 0);
            double b_sum = Sum(img, 2);

            // second equation
            uint r_max_squared = (byte)(maxes.r * maxes.r);
            uint b_max_squared = (byte)(maxes.b * maxes.b);

            Bitmap bm = new Bitmap(img);
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    bm.SetPixel(x, y, Color.FromArgb(
                        AdjustChannel_WhitePatch(pixel.R, r_quadratic_sum, r_sum, r_max_squared, maxes.r, g_avg_x_dimensions, maxes.g, green_scale),
                        pixel.G,
                        AdjustChannel_WhitePatch(pixel.B, b_quadratic_sum, b_sum, b_max_squared, maxes.r, g_avg_x_dimensions, maxes.g, green_scale)));
                }
            }

            return bm;
        }

        public static Bitmap WhitePatch2(Image img, double green_scale)
        {
            D_Color maxes = Maxes(img);
            double alfa = maxes.g / maxes.r;
            double beta = maxes.g / maxes.b;

            Bitmap bm = new Bitmap(img);
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    var pixel = bm.GetPixel(x, y);
                    bm.SetPixel(x, y,
                        Color.FromArgb((byte)(alfa * pixel.R), pixel.G, (byte)(beta * pixel.B)));
                }
            }

            return bm;
        }

        public static Bitmap Iterative(Image img)
        {
            return new Bitmap(1, 1);
        }

        private static D_Color Means(Image img)
        {
            double r, g, b;
            r = g = b = 0;
            using (var bm = new Bitmap(img))
            {
                var pixel_count = bm.Width * bm.Height;
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        r += bm.GetPixel(x, y).R;
                        g += bm.GetPixel(x, y).G;
                        b += bm.GetPixel(x, y).B;
                    }
                }

                r /= pixel_count;
                g /= pixel_count;
                b /= pixel_count;
            }

            return new D_Color { r = r, g = g, b = b };
        }

        private static D_Color Maxes(Image img)
        {
            int r, g, b;
            r = g = b = 0;
            using (var bm = new Bitmap(img))
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        int R = bm.GetPixel(x, y).R,
                            G = bm.GetPixel(x, y).G,
                            B = bm.GetPixel(x, y).B;
                        r = R > r ? R : r;
                        g = G > g ? G : g;
                        b = B > b ? B : b;
                    }
                }
            }

            return new D_Color { r = r, g = g, b = b };
        }

        private static byte GetChannel(Color pixel, byte channel)
        {
            switch (channel)
            {
                case 0:
                    return pixel.R;
                case 1:
                    return pixel.G;
                case 2:
                    return pixel.B;
                default:
                    throw new Exception("Channel HAS TO BE 0, 1 or 2. Nothing else is accepted");
            }
        }

        /**
        * @param img the image to run the calculation on
        * @param channel allowed values = {0, 1, 2} 0 - red, ... ,2 - blue
        * @return the sum of the intensities of the given channel
        */
        private static double Sum(Image img, byte channel)
        {
            double sum = 0;
            using (var bm = new Bitmap(img))
            {
                for(int x = 0; x < bm.Width; x++)
                {
                    for(int y = 0; y < bm.Height; y++)
                    {
                        Color pixel = bm.GetPixel(x, y);
                        uint intensity = GetChannel(pixel, channel);
                        sum += intensity;
                    }
                }
            }

            return sum;
        }

        /**
         * @param img the image to run the calculation on
         * @param channel allowed values = {0, 1, 2} 0 - red, ... ,2 - blue
         * @return the sum of the square of the intensities of the given channel
         */
        private static double QuadraticSum(Image img, byte channel)
        {
            double sum = 0;
            using (var bm = new Bitmap(img))
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for(int y = 0; y < bm.Height; y++)
                    {
                        Color pixel = bm.GetPixel(x, y);
                        uint intensity = GetChannel(pixel, channel);
                        sum += intensity * intensity;
                    }
                }
            }

            return sum;
        }

        private static byte AdjustChannel_WhitePatch(byte intensity, double channel_quadratic_sum, double channel_sum, double channel_max_squared, double channel_max, double g_avg_x_dimensions, double g_max, double g_scale)
        {
            // u * intensity_squared + v * intensity

            /*
             * | channel_quadratic_sum    channel_sum | | u | = | g_avg_x_dimensions |
             * | channel_max_squared      channel_max | | v |   | g_max_scaled       |
             */

            double determinant = channel_quadratic_sum * channel_max - (channel_sum * channel_max_squared);

            double g_max_scaled = g_max * g_scale;

            // the roots
            double u = (g_avg_x_dimensions * channel_max - (channel_sum * g_max_scaled)) / determinant;
            double v = (channel_quadratic_sum * g_max_scaled - (g_avg_x_dimensions * channel_max_squared)) / determinant;

            return (byte)(u * intensity * intensity + v * intensity);
        }
    }
}

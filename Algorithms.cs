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
            Color means = Means(img);
            var pixel_count = img.Width * img.Height;
            float r_factor = (float)means.G / means.R;
            float b_factor = (float)means.G / means.B;

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
            Color maxes = Maxes(img);
            Color means = Means(img);
            var pixel_count = img.Width * img.Height;
            // equation right side

            // first equation
            uint g_avg_x_dimensions = (uint)(means.G * pixel_count);
            // second equation
            uint g_max_scaled = (uint)(maxes.G * green_scale);

            // equation left side

            // first equation
            UInt64 r_quadratic_sum = QuadraticSum(img, 0);
            UInt64 b_quadratic_sum = QuadraticSum(img, 2);
            uint r_sum = Sum(img, 0);
            uint b_sum = Sum(img, 2);

            // second equation
            uint r_max_squared = (byte)(maxes.R * maxes.R);
            uint b_max_squared = (byte)(maxes.B * maxes.B);

            Bitmap bm = new Bitmap(img);
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    bm.SetPixel(x, y, Color.FromArgb(
                        AdjustChannel_WhitePatch(pixel.R, r_quadratic_sum, r_sum, r_max_squared, maxes.R, g_avg_x_dimensions, maxes.G, green_scale),
                        pixel.G,
                        AdjustChannel_WhitePatch(pixel.B, b_quadratic_sum, b_sum, b_max_squared, maxes.B, g_avg_x_dimensions, maxes.G, green_scale)));
                }
            }

            return bm;
        }

        public static Bitmap Iterative(Image img)
        {
            return new Bitmap(1, 1);
        }

        private static Color Means(Image img)
        {
            int r, g, b;
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

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private static Color Maxes(Image img)
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

            return Color.FromArgb(r, g, b);
        }

        /**
        * @param img the image to run the calculation on
        * @param channel allowed values = {0, 1, 2} 0 - red, ... ,2 - blue
        * @return the sum of the intensities of the given channel
        */
        private static uint Sum(Image img, byte channel)
        {
            uint sum = 0;
            using (var bm = new Bitmap(img))
            {
                for(int x = 0; x < bm.Width; x++)
                {
                    for(int y = 0; y < bm.Height; y++)
                    {
                        uint intensity = 0;
                        switch (channel)
                        {
                            case 0:
                                intensity = bm.GetPixel(x, y).R;
                                break;
                            case 1:
                                intensity = bm.GetPixel(x, y).G;
                                break;
                            case 2:
                                intensity = bm.GetPixel(x, y).B;
                                break;
                            default:
                                throw new Exception("Channel HAS TO BE 0, 1 or 2. Nothing else is accepted");
                        }
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
        private static UInt64 QuadraticSum(Image img, byte channel)
        {
            UInt64 sum = 0;
            using (var bm = new Bitmap(img))
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for(int y = 0; y < bm.Height; y++)
                    {
                        uint intensity = 0;
                        switch(channel)
                        {
                            case 0:
                                intensity = bm.GetPixel(x, y).R;
                                break;
                            case 1:
                                intensity = bm.GetPixel(x, y).G;
                                break;
                            case 2:
                                intensity = bm.GetPixel(x, y).B;
                                break;
                            default:
                                throw new Exception("Channel HAS TO BE 0, 1 or 2. Nothing else is accepted");
                        }
                        sum += intensity * intensity;
                    }
                }
            }

            return sum;
        }

        private static byte AdjustChannel_WhitePatch(byte intensity, UInt64 channel_quadratic_sum, UInt64 channel_sum, uint channel_max_squared, byte channel_max, uint g_avg_x_dimensions, uint g_max, double g_scale)
        {
            // u * intensity_squared + v * intensity

            /*
             * | channel_quadratic_sum    channel_sum | | u | = | g_avg_x_dimensions |
             * | channel_max_squared      channel_max | | v |   | g_max_scaled       |
             */

            UInt64 determinant = channel_quadratic_sum * channel_max - (channel_sum * channel_max_squared);

            double g_max_scaled = g_max * g_scale;

            // the roots
            double u = (double)(g_avg_x_dimensions * channel_max - (channel_sum * g_max_scaled)) / determinant;
            double v = (double)(channel_quadratic_sum * g_max_scaled - (g_avg_x_dimensions * channel_max_squared)) / determinant;

            return (byte)(u * intensity * intensity + v * intensity);
        }
    }
}

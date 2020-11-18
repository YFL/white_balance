using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using white_balance;

namespace WhiteBalance
{
    public abstract class Algorithms
    {
        public static Bitmap GrayWorld(in Image img)
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

        public static Bitmap WhitePatch(in Image img, double green_scale)
        {
            D_Color maxes = Maxes(img);
            D_Color maxes_squared = MaxesSquared(img);
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
            double r_max_squared = maxes_squared.r;
            double b_max_squared = maxes_squared.b;

            Bitmap bm = new Bitmap(img);
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    bm.SetPixel(x, y, Color.FromArgb(
                        AdjustChannel_WhitePatch(pixel.R, r_quadratic_sum, r_sum, maxes_squared.r, maxes.r, g_avg_x_dimensions, maxes.g, green_scale),
                        pixel.G,
                        AdjustChannel_WhitePatch(pixel.B, b_quadratic_sum, b_sum, maxes_squared.b, maxes.b, g_avg_x_dimensions, maxes.g, green_scale)));
                }
            }

            return bm;
        }

        public static Bitmap WhitePatch2(in Image img, double green_scale)
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
                        Color.FromArgb((byte)Math.Round((alfa * pixel.R)), pixel.G, (byte)Math.Round((beta * pixel.B))));
                }
            }

            return bm;
        }

        public static Bitmap Iterative(in Image img, double nu, double down_scale)
        {
            List<YUV> pixels = new List<YUV>();
            List<YUV> gray_points = new List<YUV>();

            Bitmap bm = new Bitmap(img);
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    pixels.Add(RGBtoYUV(bm.GetPixel(x, y)));
                }
            }

            Console.WriteLine(pixels.Count + " " + bm.Width * bm.Height);

            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    var pixel = pixels[y * bm.Width + x];
                    if((Math.Abs(pixel.U) + Math.Abs(pixel.V)) / pixel.Y < nu)
                    {
                        gray_points.Add(pixel);
                    }
                }
            }

            double u_avg = 0, v_avg = 0;
            foreach (YUV point in gray_points)
            {
                u_avg += point.U;
                v_avg += point.V;
            }

            if (gray_points.Count > 0)
            {
                u_avg /= (double)gray_points.Count;
                v_avg /= (double)gray_points.Count;
            }

            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    Color point = bm.GetPixel(x, y);
                    YUV yuv = RGBtoYUV(point);

                    if (u_avg > v_avg)
                    {
                        yuv.U *= down_scale;
                    }
                    else if (v_avg > u_avg)
                    {
                        yuv.V *= down_scale;
                    }

                    bm.SetPixel(x, y, YUVtoRGB(yuv));
                }
            }

            return bm;
        }

        private static D_Color Means(in Image img)
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

        private static D_Color Maxes(in Image img)
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

        private static D_Color MaxesSquared(in Image img)
        {
            int r, g, b;
            r = g = b = 0;
            using (var bm = new Bitmap(img))
            {
                for(int x = 0; x < bm.Width; x++)
                {
                    for(int y = 0; y < bm.Height; y++)
                    {
                        var pixel = bm.GetPixel(x, y);
                        r = pixel.R * pixel.R > r ? pixel.R * pixel.R : r;
                        g = pixel.G * pixel.G > r ? pixel.G * pixel.G : g;
                        b = pixel.B * pixel.B > b ? pixel.B * pixel.B : b;
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
        private static double Sum(in Image img, byte channel)
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
        private static double QuadraticSum(in Image img, byte channel)
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

        private static YUV RGBtoYUV(Color c)
        {
            D_Color d = new D_Color();
            d.r = c.R;
            d.g = c.G;
            d.b = c.B;

            return DColorToYUV(d);
        }

        /** Algorithm got from https://patrickwu.space/2016/06/12/csharp-color/#rgb2yuv */
        private static YUV DColorToYUV(D_Color d)
        {
            YUV yuv = new YUV();

            //normalize 
            double r = d.r / 255.0;
            double g = d.g / 255.0;
            double b = d.b / 255.0;

            // convert
            yuv.Y = 0.299 * r + 0.587 * g + 0.114 * b;
            yuv.U = -0.14713 * r - 0.288886 * g + 0.436 * b;
            yuv.V = 0.615 * r - 0.51499 * g - 0.10001 * b;

            return yuv;
        }

        /** Algorithm got from https://patrickwu.space/2016/06/12/csharp-color/#yuv2rgb */
        private static Color YUVtoRGB(YUV y)
        {
            int r = Math.Min(255, Convert.ToInt32((y.Y + 1.1398373983737983740 * y.V) * 255));
            int g = Math.Min(255, Convert.ToInt32((y.Y - 0.3946517043589703515 * y.U - 0.5805986066674976801 * y.V) * 255));
            int b = Math.Min(255, Convert.ToInt32((y.Y + 2.032110091743119266 * y.U) * 255));

            return Color.FromArgb(r, g, b);
        }
    }
}

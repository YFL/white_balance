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

        public static Bitmap WhitePatch(Image img)
        {
            return new Bitmap(1, 1);
        }

        public static Bitmap Iterative(Image img)
        {
            return new Bitmap(1, 1);
        }

        private static Color Means(Image img)
        {
            int r, g, b;
            r = g = b = 0;
            var bm = new Bitmap(img);
            var pixel_count = bm.Width * bm.Height;
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    r += bm.GetPixel(x, y).R;
                    g += bm.GetPixel(x, y).G;
                    b += bm.GetPixel(x, y).B;
                }
            }

            r /= pixel_count;
            g /= pixel_count;
            b /= pixel_count;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using white_balance;

namespace WhiteBalance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenPicture.Image = white_balance.ImageLoader.LoadImage(ofd.FileName);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ModifiedPicture.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "jpg";
                saveFileDialog.Filter = "JPEG Images|*.jpg;*.jpeg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bm = new Bitmap(ModifiedPicture.Image))
                    {
                        bm.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    }
                }
            }
        }

        private void GreyButton_Click(object sender, EventArgs e)
        {
            if(OpenPicture.Image != null)
            {
                ModifiedPicture.Image = Algorithms.GrayWorld(OpenPicture.Image);
            }
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            if (OpenPicture.Image != null)
            {
                ModifiedPicture.Image = Algorithms.WhitePatch(OpenPicture.Image, (double)GreenScaleSpinBox.Value);
            }
        }

        private void IterativeButton_Click(object sender, EventArgs e)
        {
            if(OpenPicture.Image != null)
            {
                ModifiedPicture.Image = Algorithms.Iterative(OpenPicture.Image, 0.1);
            }
        }
    }
}

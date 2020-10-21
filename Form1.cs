using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}

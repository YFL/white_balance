﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenPicture.Image = white_balance.ImageLoader.LoadImage(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Dispose();
            }
        }

        private void GreyButton_Click(object sender, EventArgs e)
        {
            if(OpenPicture.Image != null)
            {
                ModifiedPicture.Image = Algorithms.GrayWorld(OpenPicture.Image);
            }
        }

  

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

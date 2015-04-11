using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorEditor
{
    public partial class Form2 : Form
    {
        public Form2(int imgWidth, int imgHeight)
        {
            InitializeComponent();
            ImageWidth = imgWidth;
            ImageHeight = imgHeight;
        }

        private int imageWidth, imageHeight;

        public int ImageHeight
        {
            get { return imageHeight; }
            set { 
                imageHeight = value;
                textBox2.Text = imageHeight.ToString();
            }
        }

        public int ImageWidth
        {
            get { return imageWidth; }
            set { 
                imageWidth = value;
                textBox1.Text = imageWidth.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImageWidth = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception) { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImageHeight = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception) { }
        }
    }
}

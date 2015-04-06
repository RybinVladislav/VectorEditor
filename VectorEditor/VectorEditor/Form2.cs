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
        public Form2()
        {
            InitializeComponent();
            Width = 0;
            Height = 0;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Width = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception) { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Height = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception) { }
        }
    }
}

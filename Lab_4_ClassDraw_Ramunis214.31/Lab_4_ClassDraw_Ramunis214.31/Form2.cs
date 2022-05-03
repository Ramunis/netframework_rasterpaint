using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_ClassDraw_Ramunis214._31
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string text;
        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            Close();
        }
    }
}

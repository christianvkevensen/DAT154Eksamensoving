using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MouseMove += b2_Move;
        }

        private void b2_Move(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            b2.Location = new Point(r.Next(0,10), r.Next(0, 10));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b1.Text = "swag";
        }

    }
}

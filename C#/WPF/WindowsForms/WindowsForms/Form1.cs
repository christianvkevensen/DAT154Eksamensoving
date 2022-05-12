using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.MouseMove += onHover;
        }

        private void onHover(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            button1.Location = new Point(r.Next(0, 400), r.Next(0, 300));
        }
    }
}

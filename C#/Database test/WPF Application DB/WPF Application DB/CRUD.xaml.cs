using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Application_DB
{
    /// <summary>
    /// Interaction logic for CRUD.xaml
    /// </summary>
    public partial class CRUD : Window
        
    {
        dat154Entities dx;
        public CRUD()
        {
            InitializeComponent();
        }
        public CRUD(dat154Entities d)
        {
            InitializeComponent();
            dx = d;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            student s = new student();

            s.id = int.Parse(sId.Text);
            s.studentname = sName.Text;
            s.studentage = int.Parse(sAge.Text);

            dx.student.Add(s);

            dx.SaveChanges();
            sName.Text = sId.Text = sAge.Text = "";
        }
    }
}

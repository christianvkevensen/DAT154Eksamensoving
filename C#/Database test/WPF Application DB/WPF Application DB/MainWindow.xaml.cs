using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Application_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dat154Entities dx = new dat154Entities();

        DbSet<student> students;
        DbSet<grade> grades;
        DbSet<course> courses;

        

        

        public MainWindow()
        {
            InitializeComponent();

            students = dx.student;
            courses = dx.course;
            grades = dx.grade;

            students.Load();
            var studentList = students.Local;

            studentGrid.ItemsSource = studentList;
        }

        private void Button_SearchStudent(object sender, RoutedEventArgs e)
        {
            var studentList = students.Local.Where(s => s.studentname.Contains(studentBox.Text)).ToList();
            
            studentGrid.ItemsSource = studentList;
        }

        private void Button_DeleteStudent(object sender, RoutedEventArgs e)
        {
            if(studentGrid.SelectedItem != null)
            {
                var studentList = students.Local.Where(s => s != studentGrid.SelectedItem).ToList();
                studentGrid.ItemsSource=studentList;
                dx.SaveChanges();
            }
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CRUD(dx).ShowDialog();
        }
    }
}

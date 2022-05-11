using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

namespace WPFOving
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentEntities studentEntities = new StudentEntities();
        List<student> students = new List<student>();
        List<grade> grades = new List<grade>();
        List<course> courses = new List<course>();
        public MainWindow()
        {
            InitializeComponent();
            fetchData();

            
            studentDG.ItemsSource = students;
            gradeDG.ItemsSource = grades;
            CourseDG.ItemsSource = courses;

            
            //students.RemoveAt(1);

        }
        public void fetchData()
        {
            students =  studentEntities.student.ToList();
            courses =  studentEntities.course.ToList();
            grades =  studentEntities.grade.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void studentDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            student s = (student)studentDG.SelectedItem;
            if(s!= null)
            {

                var tempgrades = grades.Where(g => g.studentid == s.id).ToList();
                gradeDG.ItemsSource = tempgrades;

            }
        }

        private void studentDG_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            student s = e.Row.DataContext as student;
            student sDb = studentEntities.student.Find(s.id);
            if (sDb != null)
            {
                sDb = s;
                studentEntities.SaveChanges();
            }
            
        }

        private void CourseDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            course c = (course)CourseDG.SelectedItem;
            if(c != null)
            {
                var tempgrades= grades.Where(g=> g.coursecode == c.coursecode).ToList();
                gradeDG.ItemsSource = tempgrades;
            }
        }

    }
}

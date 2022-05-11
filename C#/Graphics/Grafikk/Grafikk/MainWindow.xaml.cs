using Grafikk.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Grafikk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += timer_Tick;
            timer.Start();
            MouseDown += mouse_leftclick;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            ClearCanvas();
            foreach(Car car in cars)
            {
                car.MoveE();
            }
            DrawCars();
        }
        public void mouse_leftclick(object sender, EventArgs e)
        {
            Car c = new Car(0, 200);
            cars.Add(c);

        }
        public Rectangle DrawCar(Car c)
        {
            Brush blue = new SolidColorBrush(Colors.Blue);
            Rectangle rect = new Rectangle();
            rect.Width = 10;
            rect.Height = 10;
            rect.Fill = blue;
            return rect;
        }
        public void DrawCars()
        {
            foreach(Car c in cars)
            {
                Rectangle rect = DrawCar(c);
                Canvas.SetLeft(rect, c.x);
                Canvas.SetTop(rect, c.y);
                canvasArea.Children.Add(rect);
            }
        }

        public void ClearCanvas()
        {
            for(int i = canvasArea.Children.Count - 1; i >= 0; i--)
            {
                UIElement Child = canvasArea.Children[i];
                canvasArea.Children.Remove(Child);
                
            }
        }

    }
}

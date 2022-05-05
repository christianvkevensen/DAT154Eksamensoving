using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolarSystem2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double scale = 500;
        double z = 1.0;
        List<SpaceObject> solarSystem = new List<SpaceObject>();
        double days = 0;
        bool label_C = true;
        //ScaleTransform scaler = new ScaleTransform();
        

        public MainWindow()
        {
            InitializeComponent();
            //canvasArea.RenderTransform = scaler;
            solarSystem = (new SolarSystem()).getSolar();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(500000)
            };
            timer.Tick += t_Tick;
            timer.Start();
            //MouseLeftButtonDown += m_zoomIn;
            //MouseRightButtonDown += m_zoomOut;
            label_chk.Checked += label_Checked;
            label_chk.Unchecked += label_Unchecked;
            

        }

        private void onClickElippse(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse)
            {
                Ellipse obj = (Ellipse)sender;
                SpaceObject temp = null;
                foreach (SpaceObject spaceObject in solarSystem)
                {
                    if (spaceObject.object_radius / scale == obj.Height)
                    {
                        temp = spaceObject;

                    }
                }
                if(temp != null)
                {
                    String infoStr = temp.name + "\n" + temp.object_radius + "\n" + temp.orbital_period;
                    infoBox.Text = infoStr;
                }
               
            }
        }

        private void label_Unchecked(object sender, RoutedEventArgs e)
        {
            label_C = false;
        }

        private void label_Checked(object sender, RoutedEventArgs e)
        {
            label_C = true;
        }


        private void m_zoomOut(object sender, MouseButtonEventArgs e)
        {
            var scaler = canvasArea.RenderTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(z, z);
                canvasArea.LayoutTransform = scaler;
            }
            z += 0.1;
            scaler.ScaleX *= z;
            scaler.ScaleY *= z;
        }

        private void m_zoomIn(object sender, MouseButtonEventArgs e)
        {
            var scaler = canvasArea.RenderTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(z, z);
                canvasArea.LayoutTransform = scaler;
            }
            z -= 0.1;
            scaler.ScaleX *= z;
            scaler.ScaleY *= z;
        }
       
        private void t_Tick(object? sender, EventArgs e)
        {
            clearSpace();
            foreach (SpaceObject obj in solarSystem)
            {
                spaceObject(obj);
            }
            days += 1;
        }

        public void spaceObject(SpaceObject obj)
        {

            obj.calculate_pos(days);
            double x = obj.x + ((canvasArea.ActualWidth - ((obj.object_radius) / scale)) / 2);
            double y = obj.y + ((canvasArea.ActualHeight - ((obj.object_radius) / scale)) / 2);
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(obj.color));
            ellipse.Width = obj.object_radius / scale;
            ellipse.Height = obj.object_radius / scale;

            ellipse.MouseLeftButtonDown += onClickElippse;


            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);

            canvasArea.Children.Add(ellipse);

            if (label_C)
            {
                Label label = new Label();
                label.Content = obj.name;
                label.Foreground = Brushes.White;
                Canvas.SetLeft(label, x);
                Canvas.SetTop(label, y);
                canvasArea.Children.Add(label);
            }


            

        }

        public void clearSpace()
        {
            canvasArea.Children.Clear();
        }

        private void button_zoomOut(object sender, RoutedEventArgs e)
        {
            var scaler = canvasArea.RenderTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(z, z);
                canvasArea.LayoutTransform = scaler;
            }
            z += 0.1;
            scaler.ScaleX *= z;
            scaler.ScaleY *= z;
        }

        private void button_zoomIn(object sender, RoutedEventArgs e)
        {
            var scaler = canvasArea.RenderTransform as ScaleTransform;

            if (scaler == null)
            {
                scaler = new ScaleTransform(z, z);
                canvasArea.LayoutTransform = scaler;
            }
            z -= 0.1;
            scaler.ScaleX *= z;
            scaler.ScaleY *= z;
        }
    }
}
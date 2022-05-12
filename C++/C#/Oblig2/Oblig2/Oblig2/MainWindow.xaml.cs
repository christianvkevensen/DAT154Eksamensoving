using SolarSystem2;
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

namespace Oblig2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double scale = 500;
        List<SpaceObject> solarSystem = new List<SpaceObject>();

        public MainWindow()
        {
            InitializeComponent();
            solarSystem = (new SolarSystem()).getSolar();
           
            canvasSpace.VerticalAlignment = VerticalAlignment.Center;
            canvasSpace.HorizontalAlignment = HorizontalAlignment.Center;
            double scale = 50;
            foreach(SpaceObject s in solarSystem)
            {
                createPlanet(s);

            }
            //Star Sun = new Star("Sun", 0, 0, 69635, 0, "YELLOW");

        }
        public void createPlanet(SpaceObject spaceObject)
        {
            Ellipse ellipse = new Ellipse();

            ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(spaceObject.color));
            ellipse.Height = spaceObject.rotational_period / scale;
            ellipse.Width = spaceObject.rotational_period / scale;
            double left = canvasSpace.Width / 50;
            double height = canvasSpace.Height / 50;

            
            
            
            canvasSpace.Children.Add(ellipse);
        }
    }
    
}

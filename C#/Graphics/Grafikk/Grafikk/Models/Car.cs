using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Grafikk.Models
{
    public class Car
    {
        public int x { get; set; }
        public int y { get; set; }

        public Car(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void MoveE()
        {
            x += 10;
        }
        public void MoveN()
        {
            x += 10;
        }

       
    }
}

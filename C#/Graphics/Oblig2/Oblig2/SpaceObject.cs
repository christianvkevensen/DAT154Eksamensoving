using System;
using System.Collections.Generic;

namespace SolarSystem2
{
    public class SpaceObject
    {
        public String name;
        public double orbital_radius { get; set; }
        public double orbital_period { get; }
        public double rotational_period { get; set; }
        public double object_radius { get; set; }
        public string color { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public SpaceObject Parent { get; set; }
        public List<SpaceObject> Children = new List<SpaceObject>();

        public SpaceObject(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color)
        {
            this.name = name;
            this.orbital_radius = orbital_radius;
            this.orbital_period = orbital_period;
            this.rotational_period = rotational_period;
            this.object_radius = object_radius;
            this.color = color;
            this.x = 0;
            this.y = 0;

        }
        public void setParent(SpaceObject parent)
        {
            this.Parent = parent;
        }

        public void setChild(SpaceObject child)
        {
            this.Children.Add(child);
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public void calculate_pos(double time)
        {
            double x;
            double y;
            if (this.orbital_radius != 0)
            {
                double rad = 2 * Math.PI * (time / orbital_period);
                x = (int)(orbital_radius * Math.Cos(rad));
                y = (int)(orbital_radius * Math.Sin(rad));
                if (Parent != null)
                {
                    Parent.calculate_pos(time);
                    x += Parent.x;
                    y += Parent.y;
                }
            }
            else
            {
                x = 0;
                y = 0;
            }
            this.x = x;
            this.y = y;
        }


    }
    public class Comet : SpaceObject
    {
        public Comet(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }
    public class Asteroid : SpaceObject
    {
        public Asteroid(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }
    public class Dwarf : Planet
    {
        public Dwarf(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Dwarf : ");
            base.Draw();
        }
    }
    public class Star : SpaceObject
    {
        public Star(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }
    public class Planet : SpaceObject
    {
        public Planet(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
    public class Moon : Planet
    {
        public Moon(string name, double orbital_radius, double orbital_period, double object_radius, double rotational_period, string color) : base(name, orbital_radius, orbital_period, object_radius, rotational_period, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }
}
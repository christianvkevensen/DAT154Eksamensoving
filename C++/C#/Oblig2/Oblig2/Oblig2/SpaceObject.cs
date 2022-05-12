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
        public int x { get; set; }
        public int y { get; set; }

        public SpaceObject Parent { get; set; }
        public List<SpaceObject> Children { get; set; }

        public SpaceObject(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color)
        {
            this.name = name;
            this.orbital_radius = orbital_radius;
            this.orbital_period = orbital_period;
            this.rotational_period = rotational_period;
            this.object_radius = object_radius;
            this.color = color;
            this.Children = new List<SpaceObject>();
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
            if (this.orbital_radius != 0)
            {
                double rad = 2 * Math.PI * (time / orbital_period);
                this.x = (int)(orbital_radius * Math.Cos(rad));
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
        }

    }
    public class Comet : SpaceObject
    {
        public Comet(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
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
        public Asteroid(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
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
        public Dwarf(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
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
        public Star(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
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
        public Planet(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
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
        public Moon(string name, double orbital_radius, double orbital_period, double rotational_period, double object_radius, string color) : base(name, orbital_radius, orbital_period, rotational_period, object_radius, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }
}
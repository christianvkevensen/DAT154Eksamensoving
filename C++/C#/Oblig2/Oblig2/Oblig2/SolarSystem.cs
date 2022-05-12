using SolarSystem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class SolarSystem
    {

        private List<SpaceObject> solarSystem = new List<SpaceObject>();
        public List<SpaceObject> getSolar()
        {
            Star Sun = new Star("Sun", 0, 0, 69635, 0, "YELLOW");
            Planet Mercury = new Planet("Mercury", 57.9, 88, 2440, 59, "BLUE");
            Planet Venus = new Planet("Venus", 108.2, 224.7, 6052, 243, "BROWN");
            Planet Earth = new Planet("Earth", 149.6, 365.26, 6371, 1, "BLUE");
            Planet Mars = new Planet("Mars", 227.9, 686.98, 3402, 1.025, "RED");

            Moon TheMoon = new Moon("The Moon", 0.384, 27.322, 1737.1, 27, "GRAY");
            Moon Phobos = new Moon("Phobos", 0.000009, 0.3189, 11.25, 0.3, "GRAY");


            Mercury.setParent(Sun);
            Venus.setParent(Sun);
            Earth.setParent(Sun);
            Mars.setParent(Sun);

            TheMoon.setParent(Earth);
            Phobos.setParent(Mars);

            Earth.setChild(TheMoon);
            Mars.setChild(Phobos);

            solarSystem.Add(Sun);
            solarSystem.Add(Mercury);
            solarSystem.Add(Venus);
            solarSystem.Add(Earth);
            solarSystem.Add(Mars);

            solarSystem.Add(TheMoon);
            solarSystem.Add(Phobos);
            return solarSystem;
        }
    }
}

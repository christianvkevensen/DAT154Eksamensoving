﻿namespace CarMVVM.Models
{
    public class Car : ICar
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }
    }
}

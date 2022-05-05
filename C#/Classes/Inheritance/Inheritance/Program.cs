// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main()
    {
        Car car = new Car();
        car.color = "Red";
        car.brand = "Porsche";

        Console.WriteLine("Color: " + car.color + " Brand: " + car.brand);
    }
}

public abstract class Vehicle
{
    public String color { get; set; }
    public String brand { get; set; }

    public int wheels;


    public abstract int GetWheels();
}

public class Car : Vehicle
{

    public override int GetWheels()
    {
        return wheels = 4;
    }
}



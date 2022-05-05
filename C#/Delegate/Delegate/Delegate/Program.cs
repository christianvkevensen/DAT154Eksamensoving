// See https://aka.ms/new-console-template for more information

public class MyProgram
{
    public static void Main()
    {
        new A();
    }
}

public delegate void testDel();

public class Kalkulator{
    public Kalkulator()
    {
    }
    public int pluss(int x, int y)
    {
        Console.WriteLine(x + y);
        return x + y;
    }
    public int minus(int x, int y)
    {
        Console.WriteLine(x - y);
        return x - y;
    }
}
//public delegate int utregnDel(int x, int y);

public class A
{
    public Func<int,int,int> del;
    public Action del2;


    public A()
    {
        Kalkulator kalkulator = new Kalkulator();
        del += kalkulator.pluss;
        del += kalkulator.minus;
        del(1, 2);

    }

}



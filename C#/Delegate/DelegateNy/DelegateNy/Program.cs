using System;
namespace DelegateNy
{
    class Program
    {
        public static Func<int, int>? del;
        public static int pluss(int x)
        {
            Console.WriteLine(x + x);
            return x + x;
        }

        public static int divided(int x)
        {
            Console.WriteLine(x / 2);

            return x / 2;
        }
        public static int times(int x)
        {
            Console.WriteLine(x*x);
            return x * x;
        }

        public static void Main(string[] args)
        {
            del += pluss;
            del += divided;
            del += times;

    }
} 
}
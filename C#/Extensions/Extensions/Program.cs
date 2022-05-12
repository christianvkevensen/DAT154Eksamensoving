// See https://aka.ms/new-console-template for more information
namespace Extensions
{

    public static class Program
    {
        
        public static void Main(string [] args)
        {

            int x = 5;
            Console.WriteLine(x.Multi().Multi());
            string y = "dasdsgtrwavrg".Sort();
            Console.WriteLine(y);

        }
        public static int Multi(this int x)
        {
            return x * x * x;
        }
        public static string Sort(this string str)
        {
            return string.Concat(str.OrderBy(c => c));

        }
    }
    
}

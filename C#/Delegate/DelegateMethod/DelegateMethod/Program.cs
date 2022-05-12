namespace DelegateMethod
{
    public class Program
    {
        public static bool isEqual(int x)
        {
            if(x % 2 == 0)
            {
                return true;
            }
            return false;
        }
        public static bool isOdd(int x)
        {
            if(x % 2 == 1)
            {
                return true;
            }
            return false;
        }
        public delegate bool DelegateBool(int x);

        public static void Test(int x, DelegateBool del)
        {
            Console.WriteLine(del(x));
        }
        public static void Test2(int x, Func<int,bool> del)
        {
            Console.WriteLine(del(x));
        }
        public static void Main()
        {
            Test(3, isEqual);
            Test2(3, isOdd);
        }
    }
}
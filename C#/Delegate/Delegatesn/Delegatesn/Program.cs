B b = new B();
A a = new A();
b.letsDoThatFileCopy(a.CopyMyFiles);

public class A
{
    public void CopyMyFiles(string infil, string outfile,Action delg)
    {
        delg();
    }
}

public class B
{
    public void letsDoThatFileCopy(Action<string, string, Action> delg) 
    {

        delg("dede", "dedenew", MyCallback);
    }

    public void MyCallback()
    {
        Console.WriteLine("copied now");
    }
}

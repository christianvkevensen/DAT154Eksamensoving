using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   
B b = new B();
b.letsDoThatFileCopy();
     
public class A
{
    public void CopyMyFiles(string infil, string outfile, B b)
    {
        b.MyCallback();
    }
}

public class B
{
    public void letsDoThatFileCopy()
    {
        A a = new A();
        a.CopyMyFiles("dede", "dedenew", this);
    }

    public void MyCallback()
    {
        Console.WriteLine("copied now");
    }
}

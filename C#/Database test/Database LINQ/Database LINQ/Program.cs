// See https://aka.ms/new-console-template for more information

using System.Collections;

SimpleCollection<string> ordListe = new() { "Hello", "Du", "Teit" };
//ordListe.Add("string");
//ordListe.Add("add");

var f = ordListe.OrderBy(x=> x);
int a = 25;

Console.WriteLine(a.Square());

foreach (string str in ordListe)
{
    Console.WriteLine(str);
}

public class SimpleCollection<T> : IEnumerable<T>
{
    private List<T> data = new();

    public void Add(T item)
    {
        data.Add(item);
    }
    public T get(int index)
    {
        return data[index];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public static class ExtensionMethods
{
    public static int Square(this int x)
    {
        return x * x;
    }
}
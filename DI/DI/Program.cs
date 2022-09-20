// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Client cs = new Client(new Service());
cs.print();
cs = new Client(new Service2());
cs.print();
Console.ReadLine();
public interface Itext
{
    void print();
}

class Service : Itext
{
    public void print()
    {
        Console.WriteLine("DependancyInjection");
    }
}
class Service2 : Itext
{
    public void print()
    {
        Console.WriteLine("DependancyInjection2");
    }
}
public class Client
{
    private Itext _text;
    public Client(Itext t1)
    {
        this._text = t1;
    }
    public void print()
    {
        _text.print();
    }
}


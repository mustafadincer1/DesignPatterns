internal class Program
{
    private static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.Operation();
    }
}

class SubSystem1 { 
    
    public void Method1()
    {
        Console.WriteLine("Method1 is running");
    }

}
class SubSystem2
{
    public void Method2()
    {
        Console.WriteLine("Method2 is running");
    }
}

class Facade
{   

    private SubSystem1 SubSystem1 { get; set; }
    private SubSystem2 SubSystem2 { get; set; }

    public Facade()
    {
        SubSystem1 = new SubSystem1();
        SubSystem2 = new SubSystem2();
    }
    public void Operation()
    {
        SubSystem1.Method1();
        SubSystem2.Method2();
    }
    
}


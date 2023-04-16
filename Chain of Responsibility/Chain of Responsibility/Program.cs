internal class Program
{
    private static void Main(string[] args)
    {
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        Handler handler3 = new ConcreteHandler3();

        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        int[] requests = { 20, 50, 140, 220, 280 };

        foreach (var item in requests)
        {
            handler1.HandleRequest(item);
        }

    }
}



abstract class Handler 
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int x);
  
    
}

class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int x)
    {
        if(x > 0 && x < 100)
        {
            Console.WriteLine($"{this.GetType().Name} handles request {x}");
        } 
        else if (successor != null)
        {
            successor.HandleRequest(x);
        }
    }
}

class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int x)
    {
        if (x > 100 && x < 200)
        {
            Console.WriteLine($"{this.GetType().Name} handles request {x}");
        }
        else if(successor != null)
        {
            successor.HandleRequest(x);
        }

    }
}

class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int x)
    {
        if (x > 200)
        {
            Console.WriteLine($"{this.GetType().Name} handles request {x}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(x);
        }

    }
}

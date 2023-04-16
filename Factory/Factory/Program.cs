internal class Program
{
    private static void Main(string[] args)
    {
        var x = new Client();
        x.main();
    }
}

class Client
{

    public void main()
    {
        Console.WriteLine("ConcreteCreater1 is running");
        ClientCode(new ConcreateCreator1());

        Console.WriteLine("\n \n");

        Console.WriteLine("ConcreteCreater2 is running");
        ClientCode(new ConcreateCreator2());
    }

    void ClientCode(Creator creator)
    {
        Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
    }


    public interface IProduct
    {
        string operation();

    }
    public class ConcreateProduct1 : IProduct
    {
        public string operation()
        {
            return "Result of ConcreateProduct1.";
        }
    }

    public class ConcreateProduct2 : IProduct
    {
        public string operation()
        {
            return "Result of ConcreateProduct2.";
        }
    }




    abstract class Creator
    {

        public abstract IProduct FactoryMethod();


        public string SomeOperation()
        {

            var product = FactoryMethod();

            return product.operation();
        }
    }

    class ConcreateCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreateProduct1();
        }
    }

    class ConcreateCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreateProduct2();
        }
    }
}



internal class Program
{
    private static void Main(string[] args)
    {
        var client = new Client();
        client.main();
    }
}

interface IAbstractProduct
{

    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
}


class ConcreteFactory1 : IAbstractProduct
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

class ConcreteFactory2 : IAbstractProduct
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcrateProductB2();
    }
}


interface IAbstractProductA
{
    public string UsefulFunctionA();



}

class ConcreteProductA1 : IAbstractProductA
{
    public string UsefulFunctionA()
    {
        return "The Result of A1";
    }
}

class ConcreteProductA2 : IAbstractProductA
{


    public string UsefulFunctionA()
    {
        return "The Result of A2";
    }
}

interface IAbstractProductB
{
    public string UsefulFunctionB();

    public string AnotherUsefulFunctionB(IAbstractProductA productA);
}


class ConcreteProductB1 : IAbstractProductB
{
    public string AnotherUsefulFunctionB(IAbstractProductA productA)
    {
        return "The Result of B1 with " + productA.UsefulFunctionA();
    }

    public string UsefulFunctionB()
    {
        return "The Result of B1";
    }
}

class ConcrateProductB2 : IAbstractProductB
{
    public string AnotherUsefulFunctionB(IAbstractProductA productA)
    {
        return "The Result of B2 with " + productA.UsefulFunctionA();
    }

    public string UsefulFunctionB()
    {
        return "The Result of B2";
    }
}


class Client
{
    public void ClientMethod(IAbstractProduct product)
    {
        var productA = product.CreateProductA();
        var productB = product.CreateProductB();

        Console.WriteLine(productB.UsefulFunctionB());
        Console.WriteLine(productB.AnotherUsefulFunctionB(productA));




    }

    public void main()
    {
        Console.WriteLine("Client: Testing client code with the first factory type...");
        ClientMethod(new ConcreteFactory1());

        Console.ReadKey();

        Console.WriteLine("Client: Testing client code with the second factory type...");
        ClientMethod(new ConcreteFactory2());


    }


}




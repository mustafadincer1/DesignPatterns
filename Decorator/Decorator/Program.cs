internal class Program
{
    private static void Main(string[] args)
    {
        ICar car = new Car();
        Console.WriteLine(car.Özellikler());

        CarDecorator carDecorator = new Sunroof(car);
        Console.WriteLine(carDecorator.Özellikler());

        ICar car2 = new Car();
        CarDecorator carDecorator1 = new Sunroof(new Navigasyon(car));
        Console.WriteLine(carDecorator1.Özellikler());
    }
}

interface ICar
{
    string Özellikler();
    
}

public class Car : ICar
{
    public string Özellikler() {

        return "Klasik Araba Özellikleri";
    
    }

}

abstract class CarDecorator : ICar
{
    protected ICar car;

    protected CarDecorator(ICar car)
    {
        this.car = car;
    }


    public virtual string Özellikler()
    {
        return car.Özellikler().ToString(); 
    }
}

class Sunroof : CarDecorator
{
    public Sunroof(ICar car) : base(car)
    {
    }

    public override string Özellikler()
    {
        return car.Özellikler() + " Sunroof" ;
    }

}

class Navigasyon : CarDecorator
{
    public Navigasyon(ICar car) : base(car)
    {
    }

    public override string Özellikler()
    {
        return car.Özellikler() + "  Navigasyon";
    }
}

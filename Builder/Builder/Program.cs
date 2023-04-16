//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        PizzaMaker pizzaMaker = new PizzaMaker();
//        PizzaMaker pizzaMaker2 = new PizzaMaker();

//        IPizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
//        pizzaMaker.MakePizza(margheritaBuilder);
//        Pizza margherita = margheritaBuilder.GetPizza();
//        margherita.DisplayPizza();

//        IPizzaBuilder vegetarianBuilder = new VegetarianPizzaBuilder();
//        // pizzaMaker2.MakePizza(vegetarianBuilder);
//        Pizza vegetarianPizza = vegetarianBuilder.GetPizza();
//        vegetarianPizza.DisplayPizza();
//        Console.WriteLine(vegetarianBuilder.GetPizza().getTopping());
//    }
//}

//public class Pizza
//{

//    private string crust;
//    private string sauce;
//    private string topping;

//    public Pizza(string crust, string sauce, string topping)
//    {
//        this.crust = crust;
//        this.sauce = sauce;
//        this.topping = topping;
//    }

//    public void DisplayPizza()
//    {
//        Console.WriteLine("Pizza with " + crust + " crust, " + sauce + " sauce, and " + topping + " topping.");

//    }
//    public string getCrust()
//    {
//        return crust;
//    }
//    public string getSauce()
//    {
//        return sauce;
//    }
//    public string getTopping()
//    {
//        return topping;
//    }


//}

//public interface IPizzaBuilder
//{
//    void SetCrust(string crust);
//    void SetSauce(string sauce);
//    void SetTopping(string topping);
//    Pizza GetPizza();

//}

//public class MargheritaPizzaBuilder : IPizzaBuilder
//{
//    private Pizza pizza;



//    public Pizza GetPizza()
//    {
//        return pizza;
//    }

//    public void SetCrust(string crust)
//    {
//        pizza = new Pizza(crust, pizza.getSauce(), pizza.getCrust());
//    }

//    public void SetSauce(string sauce)
//    {
//        pizza = new Pizza(pizza.getCrust(), sauce, pizza.getTopping());
//    }

//    public void SetTopping(string topping)
//    {
//        pizza = new Pizza(pizza.getCrust(), pizza.getSauce(), topping);
//    }
//    public MargheritaPizzaBuilder()
//    {
//        pizza = new Pizza("thin", "tomato", "cheese");
//    }
//}

//public class VegetarianPizzaBuilder : IPizzaBuilder
//{
//    private Pizza pizza;

//    public VegetarianPizzaBuilder()
//    {
//        pizza = new Pizza("pan", "tomato", "mushrooms and peppers");
//    }

//    public void SetCrust(string crust)
//    {
//        pizza = new Pizza(crust, pizza.getSauce(), pizza.getCrust());
//    }

//    public void SetSauce(string sauce)
//    {
//        pizza = new Pizza(pizza.getCrust(), sauce, pizza.getTopping());
//    }

//    public void SetTopping(string topping)
//    {
//        pizza = new Pizza(pizza.getCrust(), pizza.getSauce(), topping);
//    }
//    public Pizza GetPizza()
//    {
//        return pizza;
//    }
//}

//public class PizzaMaker
//{

//    public void MakePizza(IPizzaBuilder pizzaBuilder)
//    {

//        pizzaBuilder.SetCrust(pizzaBuilder.GetPizza().getCrust());
//        pizzaBuilder.SetSauce(pizzaBuilder.GetPizza().getSauce());
//        pizzaBuilder.SetTopping(pizzaBuilder.GetPizza().getTopping());

//    }

//}

using System;

// UML Diyagramındaki Product sınıfını tanımlar
public class Pizza
{
    private string crust { get; set; }
    private string sauce { get; set; }
    private string topping { get; set; }

    public string getCrust()
  {
      return crust;
 }
    public string getSauce()
  {
       return sauce;
   }
   public string getTopping()
   {
       return topping;
   }


    public Pizza(string crust, string sauce, string topping)
    {
        this.crust = crust;
        this.sauce = sauce;
        this.topping = topping;
    }

    public void DisplayPizza()
    {
        Console.WriteLine("Pizza with " + crust + " crust, " + sauce + " sauce, and " + topping + " topping.");
    }
}

// UML Diyagramındaki Builder arayüzünü tanımlar
public interface IPizzaBuilder
{
    void SetCrust(string crust);
    void SetSauce(string sauce);
    void SetTopping(string topping);
    Pizza GetPizza();
}

// UML Diyagramındaki ConcreteBuilder sınıflarını tanımlar
public class MargheritaPizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public MargheritaPizzaBuilder()
    {
        pizza = new Pizza("thin", "tomato", "cheese");
    }

    public void SetCrust(string crust)
    {
        pizza = new Pizza(crust, pizza.getSauce(), pizza.getCrust());
    }

    public void SetSauce(string sauce)
    {
        pizza = new Pizza(pizza.getCrust(), sauce, pizza.getTopping());
    }

    public void SetTopping(string topping)
    {
        pizza = new Pizza(pizza.getCrust(), pizza.getSauce(), topping);
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

public class VegetarianPizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public VegetarianPizzaBuilder()
    {
        pizza = new Pizza("pan", "tomato", "mushrooms and peppers");
    }

    public void SetCrust(string crust)
    {
        pizza = new Pizza(crust, pizza.getSauce(), pizza.getCrust());
    }

    public void SetSauce(string sauce)
    {
        pizza = new Pizza(pizza.getCrust(), sauce, pizza.getTopping());
    }

    public void SetTopping(string topping)
    {
        pizza = new Pizza(pizza.getCrust(), pizza.getSauce(), topping);
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

// UML Diyagramındaki Director sınıfını tanımlar
public class PizzaMaker                               
{                                                     
    public void MakePizza(IPizzaBuilder pizzaBuilder)
    {
       
        
        pizzaBuilder.SetTopping(pizzaBuilder.GetPizza().getTopping());
        pizzaBuilder.SetCrust(pizzaBuilder.GetPizza().getCrust());
        pizzaBuilder.SetSauce(pizzaBuilder.GetPizza().getSauce());
    }
}

// Kullanımı
class Program
{
    static void Main(string[] args)
    {
        PizzaMaker pizzaMaker = new PizzaMaker();

        IPizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
        pizzaMaker.MakePizza(margheritaBuilder);
        Pizza margheritaPizza = margheritaBuilder.GetPizza();
        margheritaPizza.DisplayPizza();

        IPizzaBuilder vegetarianBuilder = new VegetarianPizzaBuilder();
        pizzaMaker.MakePizza(vegetarianBuilder);
        Pizza vegetarianPizza = vegetarianBuilder.GetPizza();
        vegetarianPizza.DisplayPizza();
    }
}

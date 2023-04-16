internal class Program
{
    private static void Main(string[] args)
    {

        IComponent leaf = new Leaf();
        IComponent leaf1 = new Leaf();
        IComponent leaf2 = new Leaf();
        Composite composite = new Composite();

       
        composite.add(leaf);
        composite.add(leaf1);
        composite.add(leaf2);
        composite.oparation();
    }
}


interface IComponent
{
    public void oparation();
}

class Leaf : IComponent
{
    public void oparation()
    {
        Console.WriteLine("Leaf is runnin");
    }
}

class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();

    public void add(IComponent component)
    {

        children.Add(component);
    }

    public void remove(IComponent component)
    {
        children.Remove(component);
    }
    public IComponent getComponent(int index)
    {
        return children[index];
    }
    public void oparation()
    {
        Console.WriteLine("Composite is running");

        foreach (IComponent component in children)
        {
            component.oparation();
            
        }
    }
}


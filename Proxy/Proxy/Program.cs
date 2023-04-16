internal class Program
{
    private static void Main(string[] args)
    {
        IImage image = new ProxyImage("test");
        image.Display();
        image.Display();
    }
}

interface IImage
{
    void Display();
    
}

class RealImage : IImage
{
    private string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk(_filename);
    }

    private void LoadFromDisk(string fileName)
    {
        Console.WriteLine("Loading " + fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying " + _filename); 
    }


}


class ProxyImage : IImage
{
    private RealImage _image;
    private string _filename;

    public ProxyImage(string filename)
    {
        _filename=filename;

       
    }
    public void Display()
    {
       if (_image == null)
        {
            _image = new RealImage(_filename);
        

        }
       else
        {
            _image.Display();
        }
    }
}
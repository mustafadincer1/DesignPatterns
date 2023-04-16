using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {   
        Log4Net log4Net = new Log4Net();
        Ilogger ılogger = new Adapter(log4Net);
        
        ProductMenager product = new ProductMenager(ılogger);
        product.save();
    }
}

class ProductMenager {
    private Ilogger logger;

    public ProductMenager(Ilogger logger)
    {
        this.logger = logger;
    }

    public void save()
    {
        logger.log("User Data");
        Console.WriteLine("Saved");
    }
}

interface Ilogger
{

    void log(string message);
}

class EdLogger : Ilogger
{
    public void log(string message)
    {
        Console.WriteLine($"Log {message}");
    }
}

class Log4Net
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Logged with Log4Net {0}", message);
    }
}

class Adapter:Ilogger
{

    private readonly Log4Net log4net;

    public Adapter(Log4Net log4net)
    {
        this.log4net = log4net;
    }

    public void log(string message) { 
        log4net.LogMessage(message);
    
    }
}





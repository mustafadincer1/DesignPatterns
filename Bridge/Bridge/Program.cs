internal class Program
{
    private static void Main(string[] args)
    {
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SMSSender();

        // Create refined abstractions
        Message textMessage = new TextMessage(smsSender);
        Message htmlMessage = new HTMLMessage(smsSender);

        // Send messages
        textMessage.SetMessage("This is a text message");
        textMessage.Send();

        htmlMessage.SetMessage("This is an HTML message");
        htmlMessage.Send();

        Console.ReadKey();
    }
}


interface IMessageSender
{   
    void SendMessage(string message);
    
}

class SMSSender : IMessageSender
{
    public void SendMessage(string message)
    {
       Console.WriteLine($"{message} Send With Sms");
    }
}

class EmailSender : IMessageSender {

    public void SendMessage(string message)
    {
        Console.WriteLine($"{message} Send With Email");
    }

}


abstract class Message
{

    public IMessageSender sender;
    public string message;

    protected Message(IMessageSender sender)
    {
        this.sender = sender;
    }

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void SetIMessageSender(IMessageSender sender)
    {
        this.sender = sender;
    }

    public string getMessage()
    {
        return this.message;
    }

    public IMessageSender GetMessageSender()
    {
        return this.sender;
    }

    public abstract void Send();


}

class TextMessage : Message
{

    public TextMessage(IMessageSender Sender) : base(Sender) { }
    public override void Send()
    {
       sender.SendMessage(message);
    }
}

class HTMLMessage : Message
{
    public HTMLMessage(IMessageSender messageSender) : base(messageSender) { }

    public override void Send()
    {
        sender.SendMessage("<html><body>" + message + "</body></html>");
    }
}




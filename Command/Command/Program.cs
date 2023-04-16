internal class Program
{
    private static void Main(string[] args)
    {
        Light light = new Light();
        ICommand _TurnOnCommand = new TurnOnCommand(light);
        ICommand _TurnOffCommand = new TurnOffCommand(light);
        CommandManager manager = new CommandManager();
        manager.SetCommand(_TurnOnCommand);
        manager.ExecuteCommand();
        manager.SetCommand(_TurnOffCommand);
        manager.ExecuteCommand();

    }
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Lamba açıldı.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Lamba kapatıldı.");
    }
}
public interface ICommand
{
    public void Execute();
}

public class TurnOnCommand : ICommand
{
    private Light _light;

    public TurnOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {   
        _light.TurnOn();
    }
}

public class TurnOffCommand : ICommand
{
    private Light _light;

    public TurnOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

public class CommandManager
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }


}
namespace MarsRovers;

public class CommandException : Exception
{
    private static string message = "Invalid command received \"{0}\", please use only f, b, l or r";

    public CommandException(string command) : base(string.Format(message, command)) { }
}
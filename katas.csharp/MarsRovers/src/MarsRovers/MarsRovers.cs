using System.Text.RegularExpressions;
using static MarsRovers.Commands;

namespace MarsRovers;

public class MarsRovers
{
    private Gps _gps;
    private Facing _facing;

    public MarsRovers(Gps gps, Facing initialFacing)
    {
        _gps = gps ?? throw new GpsException();
        _facing = initialFacing ?? throw new FacingException();
    }
    
    public void Move(IEnumerable<string> commands)
    {
        Move(Map(commands));
    }
    
    public void Move(IEnumerable<Commands> commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case Forward:
                    MoveForward();
                    break;
                case Backward:
                    MoveBackward();
                    break;
                case Left:
                    TurnLeft();
                    break;
                case Right:
                    TurnRight();
                    break;
                default:
                    throw new CommandException(command.ToString());
            }
        }
    }

    public Gps GetPosition() => _gps;
    public char GetFacing() => _facing.GetFacing();
    
    /*
     * Lo marco como internal para esconder el método SetFacing a los usuarios de la clase
     * pero que sea visible para los estados
     */
    internal void SetFacing(Facing facing) => _facing = facing;
    
    /*
     * Uso el "ref" para que el cambio de posición se aplique en el objeto _gps, no en una copia
     */
    private void MoveForward() => _facing.Forward(ref _gps);
    private void MoveBackward() => _facing.Backward(ref _gps);
    private void TurnLeft() => _facing.TurnLeft(this);
    private void TurnRight() => _facing.TurnRight(this);
    
    private static readonly Dictionary<string, Commands> commandMap = new()
    {
        { "F", Forward },
        { "B", Backward },
        { "R", Right },
        { "L", Left },
    };
    
    private Commands[] Map(IEnumerable<string> commands)
    {
        Commands[] enumCommands = Array.Empty<Commands>();
        try
        {
            enumCommands = commands.Select(letter => commandMap[letter.ToUpper()]).ToArray();
        }
        catch (KeyNotFoundException e)
        {
            var match = Regex.Match(e.Message, @"'(.+)'");
            if (match.Success)
            {
                var missingKey = match.Groups[1].Value;
                throw new CommandException(missingKey);
            }

            throw;
        }

        return enumCommands;
    }

}
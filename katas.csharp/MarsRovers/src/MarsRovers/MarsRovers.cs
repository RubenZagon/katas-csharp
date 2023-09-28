using System.Text.RegularExpressions;

namespace MarsRovers;

public class MarsRovers
{
    private Gps _gps;
    private Facing _facing;
    private static readonly Dictionary<string, Commands> CommandMap = new()
    {
        { "F", Commands.Forward },
        { "B", Commands.Backward },
        { "R", Commands.Right },
        { "L", Commands.Left },
    };


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
                case Commands.Forward:
                    MoveForward();
                    break;
                case Commands.Backward:
                    MoveBackward();
                    break;
                case Commands.Left:
                    TurnLeft();
                    break;
                case Commands.Right:
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
    
    private IEnumerable<Commands> Map(IEnumerable<string> commands)
    {
        try
        {
            return commands.Select(letter => CommandMap[letter.ToUpper()]).ToArray();
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
    }

}
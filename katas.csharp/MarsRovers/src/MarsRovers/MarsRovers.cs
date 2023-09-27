namespace MarsRovers;

public class MarsRovers
{
    private readonly Gps _gps;
    private readonly Compass _compass;

    public MarsRovers(Gps gps, Compass compass)
    {
        _gps = gps;
        _compass = compass;
    }


    public Gps WhereYuAh()
    {
        return _gps;
    }

    public Facing WhereLukin()
    {
        return _compass.Feisin;
    }

    public void Muf(Commands[] commands)
    {
        var first = commands[0];
        switch (first)
        {
            case Commands.Forward:
                _gps.IncrementY();
                break;
            case Commands.Right:
                _compass.RotateRight();
                break;
            case Commands.Left:
                _compass.RotateLeft();
                break;
        }
    }
    
}
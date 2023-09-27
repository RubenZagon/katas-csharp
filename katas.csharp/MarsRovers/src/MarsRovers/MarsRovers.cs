namespace MarsRovers;

public class MarsRovers
{
    private Gps _gps;
    private Facing _facing;

    public MarsRovers(Gps gps, Facing initialFacing)
    {
        _gps = gps;
        _facing = initialFacing;
    }

    public Gps WhereYuAh() => _gps;
    public char WhereLukin() => _facing.GetFacing();
    
    public void SetFacing(Facing facing)
    {
        _facing = facing;
    }

    public void Forward() => _facing.Forward(ref _gps);
    public void Backward() => _facing.Backward(ref _gps);
    public void TurnLeft() => _facing.TurnLeft(this);
    public void TurnRight() => _facing.TurnRight(this);
    
    public void Muf(Commands[] commands)
    {
        throw new NotImplementedException();
    }


}
namespace MarsRovers;

public class FacingWest : Facing
{
    public void Forward(ref Gps gps) => throw new NotImplementedException();
    public void Backward(ref Gps gps) => throw new NotImplementedException();
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingSouth());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingNorth());
    public char GetFacing() => 'W';
}
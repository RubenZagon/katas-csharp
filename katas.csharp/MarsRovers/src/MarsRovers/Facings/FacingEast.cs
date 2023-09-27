namespace MarsRovers;

public class FacingEast : Facing
{
    public void Forward(ref Gps gps) => throw new NotImplementedException();
    public void Backward(ref Gps gps) => throw new NotImplementedException();
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingNorth());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingSouth());
    public char GetFacing() => 'E';
}
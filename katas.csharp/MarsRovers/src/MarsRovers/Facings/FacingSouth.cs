namespace MarsRovers;

public class FacingSouth : Facing
{
    public void Forward(ref Gps gps) => throw new NotImplementedException();
    public void Backward(ref Gps gps) => throw new NotImplementedException();
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingEast());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingWest());
    public char GetFacing() => 'S';
}
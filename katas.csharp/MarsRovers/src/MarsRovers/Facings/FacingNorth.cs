namespace MarsRovers;

public class FacingNorth : Facing
{
    public void Forward(ref Gps gps) => gps = new Gps(gps.X, gps.Y + 1);
    public void Backward(ref Gps gps) => throw new NotImplementedException();
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingWest());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingEast());
    public char GetFacing() => 'N';
}
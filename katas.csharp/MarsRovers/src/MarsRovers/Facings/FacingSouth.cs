namespace MarsRovers;

public class FacingSouth : Facing
{
    public void Forward(ref Gps gps) => gps = new Gps(gps.X, gps.Y - 1);
    public void Backward(ref Gps gps) => gps = new Gps(gps.X, gps.Y + 1);
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingEast());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingWest());
    public char GetFacing() => 'S';
}
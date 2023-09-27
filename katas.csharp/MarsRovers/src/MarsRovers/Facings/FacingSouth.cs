namespace MarsRovers;

public class FacingSouth : Facing
{
    public void Forward(ref Gps gps) => gps = new Gps(gps.X, gps.Y - 1);
    public void Backward(ref Gps gps) => gps = new Gps(gps.X, gps.Y + 1);
    public void TurnLeft(MarsRovers rover) => rover.SetFacing(new FacingEast());
    public void TurnRight(MarsRovers rover) => rover.SetFacing(new FacingWest());
    public char GetFacing() => 'S';
}
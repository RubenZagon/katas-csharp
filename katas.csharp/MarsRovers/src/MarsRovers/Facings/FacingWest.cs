namespace MarsRovers;

public class FacingWest : Facing
{
    public void Forward(ref Gps gps) => gps = new Gps(gps.X - 1, gps.Y);
    public void Backward(ref Gps gps) => gps = new Gps(gps.X + 1, gps.Y);
    public void TurnLeft(MarsRovers rover) => rover.SetFacing(new FacingSouth());
    public void TurnRight(MarsRovers rover) => rover.SetFacing(new FacingNorth());
    public char GetFacing() => 'W';
}
namespace MarsRovers;

public class FacingEast : Facing
{
    public void Forward(ref Gps gps) => gps = new Gps(gps.X + 1, gps.Y);
    public void Backward(ref Gps gps) => gps = new Gps(gps.X - 1, gps.Y);
    public void TurnLeft(MarsRovers rover) => rover.SetState(new FacingNorth());
    public void TurnRight(MarsRovers rover) => rover.SetState(new FacingSouth());
    public char GetFacing() => 'E';
}
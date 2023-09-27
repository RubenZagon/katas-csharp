namespace MarsRovers;

public interface Facing
{
    void Forward(ref Gps gps);
    void Backward(ref Gps gps);
    void TurnLeft(MarsRovers marsRovers);
    void TurnRight(MarsRovers marsRovers);
    char GetFacing();
}
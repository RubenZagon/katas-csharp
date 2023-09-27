namespace MarsRovers;

public class FacingException : Exception
{
    private const string message = "Mars Rovers need a initial facing, the facing can't be null";

    public FacingException() : base(message) { }
}
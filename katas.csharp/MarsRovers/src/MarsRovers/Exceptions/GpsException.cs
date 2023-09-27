namespace MarsRovers;

public class GpsException : Exception
{
    private const string message = "Mars Rovers need a initial position, the gps can't be null";

    public GpsException() : base(message) { }
}
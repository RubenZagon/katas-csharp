namespace MarsRovers;

public class Gps
{
    public int X { get; }
    public int Y { get; }

    public Gps(int x, int y)
    {
        X = x;
        Y = y;
    }

    protected bool Equals(Gps other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Gps)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
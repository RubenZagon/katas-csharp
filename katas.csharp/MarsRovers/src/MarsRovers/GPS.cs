namespace MarsRovers;

public class Gps
{
    private int x { get; set; }
    private int y { get; set; }

    public Gps(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void IncrementY()
    {
        y++;
    }

    protected bool Equals(Gps other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Gps)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}
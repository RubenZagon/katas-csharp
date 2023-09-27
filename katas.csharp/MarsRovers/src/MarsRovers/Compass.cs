namespace MarsRovers;

public class Compass
{
    public Facing Feisin { get; private set; }

    public Compass(Facing facing)
    {
        Feisin = facing;
    }

    public void RotateLeft()
    {
        Feisin = Feisin.RotatingLeft();
    }

    public void RotateRight()
    {
        Feisin = Feisin.RotatingRight();
    }
}

public class FacingNorth : Facing
{
    public Facing RotatingLeft()
    {
        return new FacingWest();
    }

    public Facing RotatingRight()
    {
        throw new NotImplementedException();
    }
}

public class FacingWest : Facing
{
    public Facing RotatingLeft()
    {
        throw new NotImplementedException();
    }

    public Facing RotatingRight()
    {
        throw new NotImplementedException();
    }
}

public class FacingEast : Facing
{
    public Facing RotatingLeft()
    {
        throw new NotImplementedException();
    }

    public Facing RotatingRight()
    {
        return new FacingSouth();
    }
}

public class FacingSouth : Facing
{
    public Facing RotatingLeft()
    {
        throw new NotImplementedException();
    }

    public Facing RotatingRight()
    {
        throw new NotImplementedException();
    }
}

public interface Facing
{
    Facing RotatingLeft();
    Facing RotatingRight();
}
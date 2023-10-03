namespace MarsRovers.Unit.Tests;

public class RoversShould
{
    /*
 You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
   The rover receives a character array of commands.
   Implement commands that move the rover forward/backward (f,b).
   Implement commands that turn the rover left/right (l,r).
   Implement wrapping at edges. But be careful, planets are spheres.
   Implement obstacle detection before each move to a new square. If a given sequence of commands encounters
   an obstacle, the rover moves up to the last possible point, aborts the sequence and reports the obstacle.
 */
    
    [Fact]
    public void moving_forward()
    {
        var rovers = new Rovers(new Position(0,0), new FeisingNorth());

        rovers.Move('f');
        
        rovers.GetPositionX().Should().Be(0);
        rovers.GetPositionY().Should().Be(1);
        rovers.getFacing().Should().Be('N');
    }
    
    public static IEnumerable<object[]> TurnRightData()
    {
        yield return new object[] { new FeisingNorth(), 'E' };
        yield return new object[] { new FeisingEast(), 'S' };
        yield return new object[] { new FeisingSouth(), 'W' };
        yield return new object[] { new FeisingWest(), 'N' };
    }

    
    [Theory]
    [MemberData(nameof(TurnRightData))]
    public void turn_to_the_right_change_facing(Feising initialFacing, char expected)
    {
        var rovers = new Rovers(new Position(0,0), initialFacing);

        rovers.Move('r');
        
        rovers.GetPositionX().Should().Be(0);
        rovers.GetPositionY().Should().Be(0);
        rovers.getFacing().Should().Be(expected);
    }

}

public interface Feising
{
    char getFeising();
    Feising TurnToRight();
}

public class FeisingNorth : Feising
{
    public char getFeising() => 'N';
    public Feising TurnToRight() => new FeisingEast();
}

public class FeisingEast : Feising
{
    public char getFeising() => 'E';
    public Feising TurnToRight() => new FeisingSouth();
}

public class FeisingSouth : Feising
{
    public char getFeising() => 'S';
    public Feising TurnToRight() => new FeisingWest();
}

public class FeisingWest : Feising
{
    public char getFeising() => 'W';
    public Feising TurnToRight() => new FeisingNorth();
}



public record Position(int X, int Y);

public class Rovers
{
    private Position position;
    private Feising feising;

    public Rovers(Position position, Feising feising)
    {
        this.feising = feising;
        this.position = position;
    }
    
    public void Move(char command)
    {
        if (command == 'f')
        {
            position = new Position(0,1);
        }

        if (command == 'r')
        {
            feising = feising.TurnToRight();
        }
    }

    public int GetPositionX()
    {
        
        return position.X;
    }

    public int GetPositionY()
    {
        return position.Y;
    }

    public char getFacing()
    {
        return feising.getFeising();
    }
}
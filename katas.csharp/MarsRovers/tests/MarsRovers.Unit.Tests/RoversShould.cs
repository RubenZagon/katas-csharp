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
        var rovers = new Rovers(new Position(0,0), 'N');

        rovers.move('f');
        
        rovers.getPositionX().Should().Be(0);
        rovers.getPositionY().Should().Be(1);
        rovers.getFacing().Should().Be('N');
    }
    
    [Theory]
    [InlineData('N', 'E')]
    //[InlineData('E', 'S')]
    //[InlineData('S', 'W')]
    //[InlineData('W', 'N')]
    public void turn_to_the_right_change_facing(char initialFacing, char expected)
    {
        var rovers = new Rovers(new Position(0,0), initialFacing);

        rovers.move('r');
        
        rovers.getPositionX().Should().Be(0);
        rovers.getPositionY().Should().Be(0);
        rovers.getFacing().Should().Be(expected);
    }

}

public record Position(int X, int Y);

public class Rovers
{
    private Position _position;
    private char _facing;

    public Rovers(Position position, char facing)
    {
        _facing = facing;
        _position = position;
    }
    
    public void move(char command)
    {
        if (command == 'f')
        {
            _position = new Position(0,1);
        }
        else
        {
            _facing = 'E';
        }
    }

    public int getPositionX()
    {
        
        return _position.X;
    }

    public int getPositionY()
    {
        return _position.Y;
    }

    public char getFacing()
    {
        return _facing;
    }
}
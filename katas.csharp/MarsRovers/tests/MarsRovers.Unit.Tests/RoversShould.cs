using System.ComponentModel.Design;

namespace MarsRovers.Unit.Tests;

public class RoversShould
{
    /*  Ari & Ruben  Road to BNC
 You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
   The rover receives a character array of commands.
   Implement commands that move the rover forward/backward (f,b).
   Implement commands that turn the rover left/right (l,r).
   Implement wrapping at edges. But be careful, planets are spheres.
   Implement obstacle detection before each move to a new square. If a given sequence of commands encounters
   an obstacle, the rover moves up to the last possible point, aborts the sequence and reports the obstacle.
 
 ZOMBIE
 Z -> Zero
 O -> One
 M -> Many
 B -> Boundaries 
 I -> 
 E -> 
 */
    
    
    
    public static IEnumerable<object[]> MovingForwardData()
    {
        yield return new object[] { new FeisingNorth(), new Position(0, 1) };
        yield return new object[] { new FeisingEast(), new Position(1, 0) };
        yield return new object[] { new FeisingSouth(), new Position(0, -1) };
        yield return new object[] { new FeisingWest(), new Position(-1, 0) };
    }
    
    [Theory]
    [MemberData(nameof(MovingForwardData))]
    public void moving_forward(Feising initialFacing, Position expected)
    {
        var controlPanel = new ControlPanel(new Position(0,0), initialFacing);

        controlPanel.Move("f");
        
        controlPanel.GetPosition().Should().Be(expected);
        controlPanel.GetFacing().Should().Be(initialFacing.GetFeising());
    }
    
    public static IEnumerable<object[]> MovingBackwardData()
    {
        return new[]
        {
            new object[] { new FeisingNorth(), new Position(0, -1) },
            new object[] { new FeisingEast(), new Position(-1, 0) },
            new object[] { new FeisingSouth(), new Position(0, 1) },
            new object[] { new FeisingWest(), new Position(1, 0) }
        };
    }
    
    [Theory]
    [MemberData(nameof(MovingBackwardData))]
    public void moving_backward(Feising initialFacing, Position expected)
    {
        var controlPanel = new ControlPanel(new Position(0,0), initialFacing);

        controlPanel.Move("b");
        
        controlPanel.GetPosition().Should().Be(expected);
        controlPanel.GetFacing().Should().Be(initialFacing.GetFeising());
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
        var rovers = new ControlPanel(new Position(0,0), initialFacing);

        rovers.Move("r");
        
        rovers.GetPosition().Should().Be(new Position(0, 0));
        rovers.GetFacing().Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TurnLeftData()
    {
        yield return new object[] { new FeisingNorth(), 'W' };
        yield return new object[] { new FeisingEast(), 'N' };
        yield return new object[] { new FeisingSouth(), 'E' };
        yield return new object[] { new FeisingWest(), 'S' };
    }

    [Theory]
    [MemberData(nameof(TurnLeftData))]
    public void turn_to_the_left_change_facing(Feising initialFacing, char expected)
    {
        var rovers = new ControlPanel(new Position(0,0), initialFacing);

        rovers.Move("l");
        
        rovers.GetPosition().Should().Be(new Position(0, 0));
        rovers.GetFacing().Should().Be(expected);
    }
    
    [Fact]
    public void move_with_many_commands()
    {
        var rovers = new ControlPanel(new Position(0,0), new FeisingNorth());

        rovers.Move("lflffrb");
        
        rovers.GetPosition().Should().Be(new Position(0, -2));
        rovers.GetFacing().Should().Be('W');
    }

    [Fact]
    public void use_radar()
    {
        var controlPanel = new ControlPanel(new Position(0,0), new FeisingNorth());
        var radar = new Radar(new List<Obstacle> { new(new Position(0, 1)) });
        var rovers = new Rovers(controlPanel, radar);
        
        rovers.Execute("ff");

        rovers.GetPosition().Should().Be(new Position(0, 1));
    }

}

public class Rovers
{
    private readonly ControlPanel controlPanel;
    private readonly Radar radar;

    public Rovers(ControlPanel controlPanel, Radar radar)
    {
        this.controlPanel = controlPanel;
        this.radar = radar;
    }

    public void Execute(string commands)
    {
        foreach (var command in commands)
        {
            //GetPosition();
            //Position nextPosition = controlPanel.GetNextPosition(command);
            
           // controlPanel.Move(commands, this);
        }
    }

    public Position GetPosition()
    {
        throw new NotImplementedException();
    }
}

public class Radar
{
    public Radar(IEnumerable<Obstacle> obstacles)
    {
        throw new NotImplementedException();
    }
}

public record Obstacle(Position Position);

public interface Feising
{
    char GetFeising();
    Feising TurnToRight();
    Feising TurnToLeft();
    Position MovingForward(Position position);
    Position MovingBackward(Position position);
}

public class FeisingNorth : Feising
{
    public char GetFeising() => 'N';
    public Feising TurnToRight() => new FeisingEast();
    public Feising TurnToLeft() => new FeisingWest();
    public Position MovingForward(Position position) => position with { Y = position.Y + 1 };
    public Position MovingBackward(Position position)  => position with { Y = position.Y - 1 };
}

public class FeisingEast : Feising
{
    public char GetFeising() => 'E';
    public Feising TurnToRight() => new FeisingSouth();
    public Feising TurnToLeft() => new FeisingNorth();
    public Position MovingForward(Position position) => position with { X = position.X + 1 };
    public Position MovingBackward(Position position)  => position with { X = position.X - 1 };
}

public class FeisingSouth : Feising
{
    public char GetFeising() => 'S';
    public Feising TurnToRight() => new FeisingWest();
    public Feising TurnToLeft() => new FeisingEast();
    public Position MovingForward(Position position) => position with { Y = position.Y - 1 };
    public Position MovingBackward(Position position)  => position with { Y = position.Y + 1 };
}

public class FeisingWest : Feising
{
    public char GetFeising() => 'W';
    public Feising TurnToRight() => new FeisingNorth();
    public Feising TurnToLeft() => new FeisingSouth();
    public Position MovingForward(Position position) => position with { X = position.X - 1 };
    public Position MovingBackward(Position position)  => position with { X = position.X + 1 };
}



public record Position(int X, int Y);

public class ControlPanel
{
    private Position position;
    private Feising feising;

    public ControlPanel(Position position, Feising feising)
    {
        this.feising = feising;
        this.position = position;
    }

    public void Move(string commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case 'f':
                    position = feising.MovingForward(position);
                    break;
                case 'b':
                    position = feising.MovingBackward(position);
                    break;
                case 'r':
                    feising = feising.TurnToRight();
                    break;
                case 'l':
                    feising = feising.TurnToLeft();
                    break;
            }
        }        
    }

    public Position GetPosition() => position;

    public char GetFacing()
    {
        return feising.GetFeising();
    }

    public Feising GetState() => feising;

    public Position GetNextPosition(char command)
    {
        return new Position(0, 0);
    }
}
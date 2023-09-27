namespace MarsRovers.Unit.Tests;

public class MarsRoversTests
{
    /*
 - You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
 - The rover receives a character array of commands.
 - Implement commands that move the rover forward/backward (f,b).
 - Implement commands that turn the rover left/right (l,r).
 - Implement wrapping at edges. But be careful, planets are spheres.
 - Implement obstacle detection before each move to a new square. If a given sequence of commands 
   encounters an obstacle, the rover moves up to the last possible point, aborts the sequence and
   reports the obstacle.
 */
    
    /*
     ZOMBIE Methodology for testing
        Z - Zero
        O - One
        M - Many
        B - Boundary Behavior
        I - Interface Definition
        E - Exercise Exception Behavior
     */

    #region Z - Zero

    [Fact]
    public void gps_is_invalid()
    {
        // Act
        Action act = () => new MarsRovers(null, new FacingNorth());

        // Assert
        act.Should().Throw<GpsException>()
            .WithMessage("Mars Rovers need a initial position, the gps can't be null");
    }
    
    [Fact]
    public void facing_is_invalid()
    {
        // Act
        Action act = () => new MarsRovers(new Gps(0, 0), null);

        // Assert
        act.Should().Throw<FacingException>()
            .WithMessage("Mars Rovers need a initial facing, the facing can't be null");
    }

    

    #endregion

    #region O - One
    
    public static IEnumerable<object[]> TurnRightData()
    {
        yield return new object[] { new FacingNorth(), 'E' };
        yield return new object[] { new FacingEast(), 'S' };
        yield return new object[] { new FacingSouth(), 'W' };
        yield return new object[] { new FacingWest(), 'N' };
    }
    
    [Theory]
    [MemberData(nameof(TurnRightData))]
    public void turn_right(Facing initialFacing, char expectedFacing)
    {
        var marsRovers = new MarsRovers(new Gps(0, 0), initialFacing);

        marsRovers.TurnRight();
        
        marsRovers.WhereLukin().Should().Be(expectedFacing);
    }
    
    public static IEnumerable<object[]> TurnLeftData()
    {
        yield return new object[] { new FacingNorth(), 'W' };
        yield return new object[] { new FacingEast(), 'N' };
        yield return new object[] { new FacingSouth(), 'E' };
        yield return new object[] { new FacingWest(), 'S' };
    }
    
    [Theory]
    [MemberData(nameof(TurnLeftData))]
    public void turn_left(Facing initialFacing, char expectedFacing)
    {
        var marsRovers = new MarsRovers(new Gps(0, 0), initialFacing);

        marsRovers.TurnLeft();
        
        marsRovers.WhereLukin().Should().Be(expectedFacing);
    }
    
    public static IEnumerable<object[]> ForwardData()
    {
        yield return new object[] { new FacingNorth(), new Gps(0, 1) };
        yield return new object[] { new FacingSouth(), new Gps(0, -1) };
        yield return new object[] { new FacingWest(), new Gps(-1, 0) };
        yield return new object[] { new FacingEast(), new Gps(1, 0) };
    }
    
    [Theory]
    [MemberData(nameof(ForwardData))]
    public void forward_change_position_based_on_facing(Facing initialFacing, Gps expectedPosition)
    {
        var marsRovers = new MarsRovers(new Gps(0, 0), initialFacing);

        marsRovers.Forward();
        
        marsRovers.WhereYuAh().Should().Be(expectedPosition);
    }
    
    public static IEnumerable<object[]> BackwardData()
    {
        yield return new object[] { new FacingNorth(), new Gps(0, -1) };
        yield return new object[] { new FacingSouth(), new Gps(0, 1) };
        yield return new object[] { new FacingWest(), new Gps(1, 0) };
        yield return new object[] { new FacingEast(), new Gps(-1, 0) };
    }
    
    [Theory]
    [MemberData(nameof(BackwardData))]
    public void backward_change_position_based_on_facing(Facing initialFacing, Gps expectedPosition)
    {
        var marsRovers = new MarsRovers(new Gps(0, 0), initialFacing);

        marsRovers.Backward();
        
        marsRovers.WhereYuAh().Should().Be(expectedPosition);
    }
    
    #endregion

    #region M - Many
    
    [Fact]
    public void move_when_received_many_commands()
    {
        var marsRovers = new MarsRovers(new Gps(0, 0), new FacingNorth());

        marsRovers.Muf(new[] { "f", "f", "r", "f", "f", "l", "f", "f", "r", "r", "b", "l", "b" });

        marsRovers.WhereYuAh().Should().Be(new Gps(1, 5));
    }

    #endregion
}
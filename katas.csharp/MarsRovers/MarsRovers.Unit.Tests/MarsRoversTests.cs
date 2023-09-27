using static MarsRovers.Commands;

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

    #region North

    [Fact]
    public void check_is_facing_north()
    {
        // GIVEN
        var marsRovers = new MarsRovers(new Gps(0, 0), new Compass(new FacingNorth()));

        //WHEN
        var result = marsRovers.WhereLukin();

        //THEN
        result.Should().BeOfType<FacingNorth>();
    }

    [Fact]
    public void move_one_field_north()
    {
        // GIVEN
        var marsRovers = new MarsRovers(new Gps(0, 0), new Compass(new FacingNorth()));

        //WHEN
        var commands = new[] { Forward };
        marsRovers.Muf(commands);

        //THEN
        marsRovers.WhereLukin().Should().BeOfType<FacingNorth>();
    }
    
    #endregion
}
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
}
using SimpleMarsRover;

namespace SimpleMarsRoverTest;

public class SimpleMarsRoverShould
{
    [Fact]
    public void ShouldStartInTheInitialPosition()
    {
        MarsRover marsRover = new MarsRover();
        Assert.Equal("0:0:N", marsRover.Execute(""));
    }
    [Theory]
    [InlineData("R", "0:0:E")]
    [InlineData("RR", "0:0:S")]
    [InlineData("RRR", "0:0:W")]
    public void ShouldRotateRight(string command, string expected)
    {
        MarsRover marsRover = new MarsRover();
        Assert.Equal(expected, marsRover.Execute(command));
    }
    [Fact]
    public void ShouldRotateLeft()
    {
        MarsRover marsRover = new MarsRover();
        Assert.Equal("0:0:W", marsRover.Execute("L"));
    }
}
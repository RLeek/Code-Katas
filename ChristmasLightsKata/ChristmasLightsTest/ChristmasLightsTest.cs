using ChristmasLights;

namespace ChristmasLightsTest;

public class ChristmasLightsTest
{
    [Theory]
    [InlineData(0,0, 1000, 1000, 1000*1000)]
    [InlineData(1000, 1000, 0, 0, 1000*1000)]
    public void TurnOn_GivenValidCoordinates_ReturnExpectedNumberOfOnLights(int xStart, int yStart, int xEnd, int yEnd, int expectedLightsOn)
    {
        // Arrange
        var lights = new ChristmasLights.ChristmasLights();

        // Assert
        lights.TurnOn(new LightCoordinate(xStart, yStart), new LightCoordinate(xEnd, yEnd));

        // Act
        Assert.Equal(expectedLightsOn, lights.OnLights());
    }

    [Theory]
    [InlineData(0, 0, 1000, 1000, 0)]
    [InlineData(1000, 1000, 0, 0, 0)]
    public void TurnOff_GivenValidCoordinates_ReturnExpectedNumberOfOnLights(int xStart, int yStart, int xEnd, int yEnd, int expectedLightsOn)
    {
        // Arrange
        var lights = new ChristmasLights.ChristmasLights();

        // Assert
        lights.TurnOn(new LightCoordinate(xStart, yStart), new LightCoordinate(xEnd, yEnd));
        lights.TurnOff(new LightCoordinate(xStart, yStart), new LightCoordinate(xEnd, yEnd));

        // Act
        Assert.Equal(expectedLightsOn, lights.OnLights());
    }

    [Theory]
    [InlineData(0, 0, 1000, 1000, 990000)]
    [InlineData(1000, 1000, 0, 0, 990000)]
    public void Toggle_GivenValidCoordinates_ReturnsExpectedNumberOfOnLights(int xStart, int yStart, int xEnd, int yEnd, int expectedLightsOn)
    {
        // Arrange
        var lights = new ChristmasLights.ChristmasLights();

        // Assert
        lights.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(100, 100));
        lights.Toggle(new LightCoordinate(xStart, yStart), new LightCoordinate(xEnd, yEnd));

        // Act
        Assert.Equal(expectedLightsOn, lights.OnLights());
    }

}
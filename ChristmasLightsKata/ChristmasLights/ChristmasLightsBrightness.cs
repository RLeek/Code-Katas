namespace ChristmasLights;

public class ChristmasLightsBrightness
{
    private readonly List<List<int>> lights = [];

    public ChristmasLightsBrightness()
    {
        for (int i = 0; i < 1000; i++)
        {
            var lightRow = new List<int>();
            for (int i2 = 0; i2 < 1000; i2++)
            {
                lightRow.Add(0);
            }
            lights.Add(lightRow);
        }
    }

    public void TurnOn(LightCoordinate startCoordinate, LightCoordinate endCoordinate)
    {
        var maxX = int.Max(startCoordinate.X, endCoordinate.X);
        var minX = int.Min(startCoordinate.X, endCoordinate.X);
        var maxY = int.Max(startCoordinate.Y, endCoordinate.Y);
        var minY = int.Min(startCoordinate.Y, endCoordinate.Y);

        // still need to validate (let's ignore this for now)
        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                lights[row][col] += 1;
            }
        }
    }

    public void TurnOff(LightCoordinate startCoordinate, LightCoordinate endCoordinate)
    {
        var maxX = int.Max(startCoordinate.X, endCoordinate.X);
        var minX = int.Min(startCoordinate.X, endCoordinate.X);
        var maxY = int.Max(startCoordinate.Y, endCoordinate.Y);
        var minY = int.Min(startCoordinate.Y, endCoordinate.Y);

        // still need to validate (let's ignore this for now)
        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                if (lights[row][col] > 0)
                {
                    lights[row][col]--;
                }
            }
        }
    }

    public void Toggle(LightCoordinate startCoordinate, LightCoordinate endCoordinate)
    {
        var maxX = int.Max(startCoordinate.X, endCoordinate.X);
        var minX = int.Min(startCoordinate.X, endCoordinate.X);
        var maxY = int.Max(startCoordinate.Y, endCoordinate.Y);
        var minY = int.Min(startCoordinate.Y, endCoordinate.Y);

        // still need to validate (let's ignore this for now)
        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                lights[row][col] += 2;
            }
        }
    }

    public int OnLights()
    {
        var onLights = 0;
        foreach (var row in lights)
        {
            foreach (var light in row)
            {
                onLights += light;
            }
        }
        return onLights;
    }

}

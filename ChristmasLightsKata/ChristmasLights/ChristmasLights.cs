namespace ChristmasLights;

public class ChristmasLights
{
    private readonly List<List<bool>> lights = [];

    public ChristmasLights() 
    {
        for (int i = 0; i < 1000; i++)
        {
            var lightRow = new List<bool>();
            for (int i2 = 0; i2 < 1000; i2++)
            {
                lightRow.Add(false);
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

        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                lights[row][col] = true;
            }
        }
    }
    public void TurnOff(LightCoordinate startCoordinate, LightCoordinate endCoordinate)
    {
        var maxX = int.Max(startCoordinate.X, endCoordinate.X);
        var minX = int.Min(startCoordinate.X, endCoordinate.X);
        var maxY = int.Max(startCoordinate.Y, endCoordinate.Y);
        var minY = int.Min(startCoordinate.Y, endCoordinate.Y);

        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                lights[row][col] = false;
            }
        }
    }

    public void Toggle(LightCoordinate startCoordinate, LightCoordinate endCoordinate)
    {
        var maxX = int.Max(startCoordinate.X, endCoordinate.X);
        var minX = int.Min(startCoordinate.X, endCoordinate.X);
        var maxY = int.Max(startCoordinate.Y, endCoordinate.Y);
        var minY = int.Min(startCoordinate.Y, endCoordinate.Y);

        for (int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                lights[row][col] = !lights[row][col];
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
                if (light == true)
                {
                    onLights++;
                }
            }
        }
        return onLights;
    }

}

namespace ChristmasLights;

public readonly struct LightCoordinate
{
    public LightCoordinate(int x, int y) : this()
    {
        if (x < 0 || y < 0)
        {
            throw new ArgumentException("Coordinates must be positive");
        }
        X = x;
        Y = y;
    }

    public readonly int X { get; }

    public readonly int Y { get; }

}

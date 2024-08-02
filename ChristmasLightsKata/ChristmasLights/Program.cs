namespace ChristmasLights;

internal class Program
{
    static void Main(string[] args)
    {
        var lights = new ChristmasLights();

        lights.TurnOn(new LightCoordinate(887, 9), new LightCoordinate(959, 629));
        lights.TurnOn(new LightCoordinate(454, 398), new LightCoordinate(844, 448));
        lights.TurnOff(new LightCoordinate(539, 243), new LightCoordinate(559, 965));
        lights.TurnOff(new LightCoordinate(370, 819), new LightCoordinate(676, 868));
        lights.TurnOff(new LightCoordinate(145, 40), new LightCoordinate(370, 997));
        lights.TurnOff(new LightCoordinate(145, 40), new LightCoordinate(370, 997));
        lights.TurnOff(new LightCoordinate(301, 3), new LightCoordinate(808, 453));
        lights.TurnOn(new LightCoordinate(351, 678), new LightCoordinate(951, 908));
        lights.Toggle(new LightCoordinate(720, 196), new LightCoordinate(897, 994));
        lights.Toggle(new LightCoordinate(831, 394), new LightCoordinate(904, 860));
        Console.WriteLine(lights.OnLights());

        var brightnessLights = new ChristmasLightsBrightness();

        brightnessLights.TurnOn(new LightCoordinate(887, 9), new LightCoordinate(959, 629));
        brightnessLights.TurnOn(new LightCoordinate(454, 398), new LightCoordinate(844, 448));
        brightnessLights.TurnOff(new LightCoordinate(539, 243), new LightCoordinate(559, 965));
        brightnessLights.TurnOff(new LightCoordinate(370, 819), new LightCoordinate(676, 868));
        brightnessLights.TurnOff(new LightCoordinate(145, 40), new LightCoordinate(370, 997));
        brightnessLights.TurnOff(new LightCoordinate(301, 3), new LightCoordinate(808, 453));
        brightnessLights.TurnOn(new LightCoordinate(351, 678), new LightCoordinate(951, 908));
        brightnessLights.Toggle(new LightCoordinate(720, 196), new LightCoordinate(897, 994));
        brightnessLights.Toggle(new LightCoordinate(831, 394), new LightCoordinate(904, 860));
        Console.WriteLine(brightnessLights.OnLights());
    }
}

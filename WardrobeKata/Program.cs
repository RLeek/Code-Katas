// See https://aka.ms/new-console-template for more information
using WardrobeKata;

var wardrobe = new Wardrobe(250);

Console.WriteLine("Combinations: ");

foreach (var combination in wardrobe.GetCombinations(new List<int> { 50, 75, 100, 120 }))
{
    Console.WriteLine(String.Join(",", combination));
}

Console.WriteLine("Cheapest price:");

Console.WriteLine(wardrobe.cheapestCombination(new List<int> { 50, 75, 100, 120 }, new Dictionary<int, int> { { 50, 59 }, { 75, 62 }, { 100, 90 }, { 120, 111 } }));
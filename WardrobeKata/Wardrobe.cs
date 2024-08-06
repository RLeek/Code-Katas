using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WardrobeKata;

// Using aliases was pretty much essential to make this event slightly readable/bearable to write

// Aliases to make things more readable and obvious
// Tuples to make things more readable and obvious 
// Records, to make things more readable and obvious + for adding new methods
// Classes for the whole shebang

// Basically, in order of expressibility

// Use aliases to make simple things easier to read (often when they represent different measurements etc.. or nested types)
// Use tuples to group together types and make them easier to read (often easy way of creating and managing container types)
// Use records for tuple like objects that also need additional methods and specific instantiation (thing slightly more verbose but with more customizability)
// Use classes for most expressivity and verboseness

// Try using interfaces + pattern matching




using Combination = List<int>;
using Combinations = List<List<int>>;


public class Wardrobe
{

    private readonly int size;

    public Wardrobe(int size)
    {
        this.size = size;
    }

    public Combinations GetCombinations(List<int> elements)
    {
        // Dp algorithm
        List<Combinations> combinations = new List<Combinations>();
        for (int currSize = 1; currSize <= size; currSize++)
        {
            combinations.Add(new Combinations());
            foreach(int element in elements)
            {
                if (currSize-element == 0)
                {
                    combinations[currSize - 1] = new Combinations { new Combination { element } };
                }
            }
        }

        for (int currSize = 1; currSize <= size; currSize++)
        {
            var currIndex = currSize - 1;
            foreach (int element in elements)
            {
                if (currSize-element > 0 && combinations[currSize-element-1].Count > 0)
                {
                    var currCombinations = combinations[currSize - element-1].Select(x=>x.ToList()).ToList();
                    foreach (var currCombination in currCombinations)
                    {
                        currCombination.Add(element);
                    }
                    combinations[currIndex].AddRange(currCombinations);
                }
            }
        }

        return combinations[size-1];
    }

    public int cheapestCombination(List<int> costs, Dictionary<int, int> wardrobe)
    {
        var cheapestPrice = int.MaxValue;
        var combinations = GetCombinations(costs);
        foreach (var combination in combinations)
        {
            cheapestPrice =  int.Min(cheapestPrice, combination.Select(item => wardrobe[item]).Sum());
        }

        // Will need to add check for if there are no valid combinations
        if (cheapestPrice == int.MaxValue)
        {
            // throw exception;
        }

        return cheapestPrice;

    }
}

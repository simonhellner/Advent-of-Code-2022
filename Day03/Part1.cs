#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System;
namespace Day3;

public static class Part1
{
    public class RockSack
    {
        public List<char> Compartment1 { get; set; }
        public List<char> Compartment2 { get; set; }
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        var rockSacks = input.Select(line =>
        {
            var lineArre = line.ToList();
            var charCount = lineArre.Count;
            return new RockSack()
            {
                Compartment1 = lineArre.GetRange(0, charCount / 2),
                Compartment2 = lineArre.GetRange(charCount / 2, charCount / 2),
            };
        });

        var itemsThatExistsInBothSacks = rockSacks.SelectMany(rockSack => rockSack.Compartment1.Intersect(rockSack.Compartment2));

        var prioritiesForItems = itemsThatExistsInBothSacks.Select(item =>
        {
            if (item >= 'A' && item <= 'Z') //Upper case
                return item - 'A' + 27;

            else // Lower case
                return item - 'a' + 1;
        });

        var sumOfPriorities = prioritiesForItems.Sum();

        Console.WriteLine($"Answer: {sumOfPriorities}");
    }
}

#pragma warning restore CS8618
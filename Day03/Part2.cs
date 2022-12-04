#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System;
namespace Day3;

public static class Part2
{
    public class ElfGroup
    {
        public List<string> RuckSacks { get; set; } = new();
    }

    static IEnumerable<ElfGroup> DivideInToGroups(string[] input)
    {
        var elfGroupsCount = input.Length / 3;
        var elfGroups = new ElfGroup[elfGroupsCount];

        for (int i = 0; i < input.Length; i++)
        {
            var positionInGroup = i % 3;
            var group = i / 3;
            var inputten = input[i];
            if (elfGroups[group] == null)
            {
                elfGroups[group] = new();
            }
            var dds = elfGroups[group];
            
            elfGroups[group].RuckSacks.Add(input[i]);
        }
        return elfGroups;
    }

    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");
        var elfGroups = DivideInToGroups(input);

        var groupBadges = elfGroups.SelectMany(group =>
        {
            var inAllRuckSacks = group.RuckSacks[0].Intersect(group.RuckSacks[1]).Intersect(group.RuckSacks[2]);
            return inAllRuckSacks;
        });

        var prioritesForBadges = groupBadges.Select(item =>
        {
            if (item >= 'A' && item <= 'Z') //Upper case
                return item - 'A' + 27;

            else // Lower case
                return item - 'a' + 1;
        });

        var sumOfPriorities = prioritesForBadges.Sum();

        Console.WriteLine($"Answer: {sumOfPriorities}");
    }
}

#pragma warning restore CS8618
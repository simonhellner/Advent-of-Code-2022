using System;
namespace Day4;

public static class Part2
{

    class SectionRange
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    static bool RangeIsWithinRange(SectionRange range1, SectionRange range2)
    {
        if (range1.Start >= range2.Start && range1.Start <= range2.End) 
        {
            return true;
        }

        if(range2.End >= range1.Start && range2.End <= range1.Start)
        {
            return true;
        }

        return false;
    }

    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");
        var sectionRanges = input.Select(line =>
        {
            var sectionPairs = line.Split(',');
            var pairs = sectionPairs.Select(sectionPair =>
            {
                var range = sectionPair.Split('-');
                return new SectionRange()
                {
                    Start = int.Parse(range[0]),
                    End = int.Parse(range[1])
                };
            });
            return pairs.ToArray();
        });

        int counter = 0;
        foreach (var sectionRange in sectionRanges)
        {
            bool overlapping = RangeIsWithinRange(sectionRange[0], sectionRange[1]) || RangeIsWithinRange(sectionRange[1], sectionRange[0]);
            if (overlapping)
            {
                counter++;
            }
        }

        Console.WriteLine($"[Part2] Answer: {counter}");
    }
}
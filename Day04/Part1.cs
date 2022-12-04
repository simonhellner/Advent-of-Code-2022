using System;
namespace Day4;

public static class Part1
{
    class SectionRange
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    static bool RangeIsWithinRange(SectionRange range1, SectionRange range2)
    {

        if (range1.Start <= range2.Start)
        {
            if (range1.End >= range2.End)
            {
                return true;
            }
        }
        if (range2.Start <= range1.Start)
        {
            if (range2.End >= range1.End)
            {
                return true;
            }
        }
        return false;
    }


    public static void Part1Main()
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
        foreach (var s in sectionRanges)
        {
            var firstRange = s[0];
            var secondRange = s[1];
            if (RangeIsWithinRange(s[0], s[1]))
            {
                counter++;
            }
        }

        Console.WriteLine($"[Part1] Answer: {counter}");
    }
}


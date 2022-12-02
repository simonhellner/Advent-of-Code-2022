namespace Day1;

internal class Program
{
    static void Part1()
    {
        var input = File.ReadAllText("input.txt");
        var elfs = input.Split(Environment.NewLine + Environment.NewLine);
        var elfsTotalCalories = elfs.Select(x => x.Split(Environment.NewLine).Select(y => int.Parse(y)).Sum());
        var maxCalories = elfsTotalCalories.Max();

        Console.WriteLine($"Part 1: That Elf is carrying {maxCalories} calories");
    }

    static void Part2()
    {
        var input = File.ReadAllText("input.txt");
        var elfs = input.Split(Environment.NewLine + Environment.NewLine);
        var elfsTotalCalories = elfs.Select(x => x.Split(Environment.NewLine).Select(y => int.Parse(y)).Sum()).ToList();
        
        elfsTotalCalories.Sort();
        var top3ElfsSum = elfsTotalCalories.GetRange(elfsTotalCalories.Count - 3, 3).Sum();

        Console.WriteLine($"Part 2: The top 3 Elfs are carrying {top3ElfsSum} calories");
    }

    static void Main(string[] args)
    {
        Part1();
        Part2();
    }
}

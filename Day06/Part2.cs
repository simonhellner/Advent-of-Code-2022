using System;

namespace Day06
{
    public static class Part2
    {
        public static void Part2Main()
        {
            var input = File.ReadAllText("input.txt").ToList();

            List<char> last14Characters = new();
            last14Characters.InsertRange(0, input.GetRange(0, 14));

            for (int i = 14; i < input.Count; i++)
            {
                if (last14Characters.Distinct().Count() == 14)
                {
                    Console.WriteLine($"Answer {i}");
                    break;
                }
                last14Characters.RemoveAt(0);
                last14Characters.Add(input[i]);
            }
        }
    }
}
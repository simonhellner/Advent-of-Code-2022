using System;

namespace Day06
{
    public static class Part1
    {
        public static void Part1Main()
        {
            var input = File.ReadAllText("input.txt").ToList();

            List<char> last4Characters = new();
            last4Characters.InsertRange(0, input.GetRange(0, 4));
            
            for(int i = 4; i<input.Count; i++)
            {
                if(last4Characters.Distinct().Count() == 4)
                {
                    Console.WriteLine($"Answer {i}");
                    break;
                }
                last4Characters.RemoveAt(0);
                last4Characters.Add(input[i]);
            }
        }
    }
}
using System;

namespace Day05;

public static class Part1
{
    public class MoveInstruction
    {
        public int MoveCount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }

    static List<string> GetStacksFromInput(string[] input)
    {
        var stacksInput = new List<string>();
        foreach(var line in input)
        {
            if (line == "")
                break;
            stacksInput.Add(line);
        }

       var stackRows = stacksInput
            .Select(stackLine => stackLine.Replace("[", " ").Replace("]", " "))
            .ToList();

        var flippedStacks = new List<string>();
        for(int i = 0; i<stackRows.Count -1; i++)
        {
            for (int j = 0; j < stackRows[i].Length; j++)
            {
                if (j >= flippedStacks.Count)
                {
                    flippedStacks.Add($"{stackRows[i][j]}");
                }
                else
                {
                    flippedStacks[j] += $"{stackRows[i][j]}";
                }
            }
        }

        flippedStacks = flippedStacks
            .Select(stack => stack.Replace(" ", ""))
            .Where(stack => stack.Length > 0)
            .Select(stack => new string(stack.Reverse().ToArray()))
            .ToList();



        return flippedStacks;
    }


    static List<MoveInstruction> GetMoveInstructionsFromInput(string[] input)
    {
        var instructionsStart = 0;
        while (!input[instructionsStart].Contains("move"))
            instructionsStart++;

        var moveInstructions = new List<MoveInstruction>();
        for(int i = instructionsStart; i<input.Length; i++)
        {
            var cleanInput = input[i].Replace("move ", "").Replace("from ", "").Replace("to ", "");
            var split = cleanInput.Split(' ');
            var moveInstruction = new MoveInstruction()
            {
                MoveCount = int.Parse(split[0]),
                From = int.Parse(split[1]) -1,
                To = int.Parse(split[2]) -1
            };
            moveInstructions.Add(moveInstruction);
        }
        return moveInstructions;


    }


    static void Move(List<string> stacks, MoveInstruction moveInstruction)
    {
        for(int i = 0; i<moveInstruction.MoveCount; i++)
        {
            var toBeMoved = stacks[moveInstruction.From].Last();
            stacks[moveInstruction.To] += $"{toBeMoved}";
            stacks[moveInstruction.From] = stacks[moveInstruction.From].Remove(stacks[moveInstruction.From].Length - 1);
        }
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");
        var stacks = GetStacksFromInput(input);
        var moveInstructions = GetMoveInstructionsFromInput(input);
        foreach(var moveInstruciton in moveInstructions)
        {
            Move(stacks, moveInstruciton);
        }

        string answer = "";
        foreach(var stack in stacks)
        {
            answer += $"{stack.Last()}";
        }

        Console.WriteLine($"Answer {answer}");

    }
}
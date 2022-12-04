// A = Rock Opponent 
// B = Paper Opponent
// C = Scissors Opponent

// X = Rock me
// Y = Paper me
// Z = Scissors me

// A, X = 1p
// B, Y = 2p
// C, z = 3p

// Win = 6p
// Loss = 0p,
// Draw = 3p,

internal class Program
{
    static int Rock => 1;
    static int Paper => 2;
    static int Scissors => 3;

    static readonly string[] Input = File.ReadAllLines("input.txt");
    #region part1
    public static void Part1()
    {
        var games = Input.Select(line =>
        {
            return line
           .Replace('A', '1')
           .Replace('B', '2')
           .Replace('C', '3')
           .Replace('X', '1')
           .Replace('Y', '2')
           .Replace('Z', '3');
        }).Select(line =>
        {
            var split = line.Split(' ');
            var p1 = int.Parse(split[0]);
            var p2 = int.Parse(split[1]);
            return new int[] { p1, p2 };
        });

        int score = 0;

        foreach (var game in games)
        {
            var p1 = game[0];
            var p2 = game[1];

            if (p1 == p2)
                score += 3;
            else if (p1 == Rock && p2 == Paper)
                score += 6;
            else if (p1 == Paper && p2 == Scissors)
                score += 6;
            else if (p1 == Scissors && p2 == Rock)
                score += 6;

            score += p2;
        }
        Console.WriteLine($"Part 1 score: {score}");
    }
    #endregion

    #region part2
    static char RockC => 'A';
    static char PaperC  => 'B';
    static char ScissorsC => 'C';

    static char Loose => 'X';
    static char Draw => 'Y';
    static char Win => 'Z';

    private static char GetWinner(char c)
    {
        if (c == RockC)
            return PaperC;
        else if (c == PaperC)
            return ScissorsC;
        else
            return RockC;
    }

    private static char GetLoser(char c)
    {
        if (c == RockC)
            return ScissorsC;
        else if (c == PaperC)
            return RockC;
        else
            return PaperC;

    }
    public static void Part2()
    {
        var games = Input.Select(line =>
        {
            var p1 = line[0];
            char p2;
            var howToEnd = line[2];

            if (howToEnd == Draw)
                p2 = p1; 

            else if (howToEnd == Loose)
                p2 = GetLoser(p1);

            else // if (howToEnd == Win)
                 p2 = GetWinner(p1);

            return $"{p1} {p2}";
        }).Select(line =>        
            line
           .Replace('A', '1')
           .Replace('B', '2')
           .Replace('C', '3')
           .Replace('X', '1')
           .Replace('Y', '2')
           .Replace('Z', '3')
        ).Select(line =>
        {
            var split = line.Split(' ');
            var p1 = int.Parse(split[0]);
            var p2 = int.Parse(split[1]);
            return new int[] { p1, p2 };
        });

        int score = 0;

        foreach (var game in games)
        {
            var p1 = game[0];
            var p2 = game[1];

            if (p1 == p2)
                score += 3;
            else if (p1 == Rock && p2 == Paper)
                score += 6;
            else if (p1 == Paper && p2 == Scissors)
                score += 6;
            else if (p1 == Scissors && p2 == Rock)
                score += 6;

            score += p2;
        }
        Console.WriteLine($"Part 2 score: {score}");
    }
    #endregion

    static void Main(string[] args)
    {
        Part1();
        Part2();
    }
}
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public static class Day3
{
    public static string solve()
    {
        StreamReader reader = new StreamReader("../../../inputs/Day3.txt");
        string input = reader.ReadToEnd();
        
        Regex mulRegex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        
        MatchCollection captures = mulRegex.Matches(input);

        int total = 0;

        for (int i = 0; i < captures.Count; i++)
        {
            total += int.Parse(captures[i].Groups[1].Value) * int.Parse(captures[i].Groups[2].Value);
        }
        return total.ToString();
    }
}
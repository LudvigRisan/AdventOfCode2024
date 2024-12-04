using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public static class Day3
{
    public static string solve(){
        StreamReader reader = new StreamReader("../../../inputs/Day3.txt");
        string input = reader.ReadToEnd();

        Regex doDontRegex = new Regex(@"do\(\)(?:(?!don't\(\)).)*|^(?:(?!don't\(\)).)*", RegexOptions.Singleline);
        Regex mulRegex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

        MatchCollection dos = doDontRegex.Matches(input);
        int total = 0;

        for (int j = 0; j < dos.Count; j++){
            
            MatchCollection captures = mulRegex.Matches(dos[j].Value);
            
            for (int i = 0; i < captures.Count; i++)
            {
                total += int.Parse(captures[i].Groups[1].Value) * int.Parse(captures[i].Groups[2].Value);
            }
        }
        return total.ToString();
    }
}
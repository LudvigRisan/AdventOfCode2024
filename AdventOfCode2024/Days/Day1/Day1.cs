namespace AdventOfCode2024;

public static class Day1
{
    public static string solve(){
        StreamReader reader = new StreamReader("../../../inputs/Day1.txt");
        string? line = reader.ReadLine();

        List<int> left = new List<int>();
        List<int> right = new List<int>();
        
        while (line != null){
            string[] numbers = line.Split(" ");
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[3]));
            line = reader.ReadLine();
        }
        
        left.Sort();
        right.Sort();

        int sum = 0;
        for (int i = 0; i < left.Count; i++){
            sum += left[i] * right.Count(x => x == left[i]);
        }
      
        
        return sum.ToString();
    }
}

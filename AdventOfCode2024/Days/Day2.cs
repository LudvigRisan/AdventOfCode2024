namespace AdventOfCode2024;

public class Day2
{
    public static string solve() {
        StreamReader reader = new StreamReader("../../../inputs/Day2.txt");
        string? line = reader.ReadLine();

        int safeCount = 0;

        while (line != null)
        {
            List<int> numbers = line.Split(' ').Select(int.Parse).ToList();
            
            
            bool safe = checkSafe(numbers);
            

            if(!safe) {
                for (int i = 0; i < numbers.Count; i++) {
                    List<int> temp = numbers.Select(x => x).ToList();
                    temp.RemoveAt(i);
                    if (checkSafe(temp))
                    {
                        safe = true;
                        break;
                    }
                }
            }

            if (safe)
            {
                safeCount++;
            }
            
            Console.WriteLine(safe ? "Safe" : "Unsafe");
            
            line = reader.ReadLine();
        }
        
        
        
        return safeCount.ToString();
    }

    static bool checkSafe(List<int> numbers)
    {
        int direction = Math.Sign(numbers[1] - numbers[0]);
        for (int i = 1; i < numbers.Count; i++)
        {
            if (Math.Sign(numbers[i] - numbers[i - 1]) != direction || Math.Abs(numbers[i] - numbers[i - 1]) > 3 ||
                numbers[i] == numbers[i - 1])
            {
                return false;
            }
        }

        return true;
    }
    
}
namespace AdventOfCode2024;

public class Day7
{
    static ulong opperate(ulong a, ulong b, bool multiply){
        return multiply ? (a * b) : (a + b);
    }

    static int intPow(int x, int pow){
        int ret = 1;

        for (int i = 0; i < pow; i++){
            ret *= x;
        }

        return ret;
    }
    
    static bool testSequence(ulong sum, ulong[] parts){
        for (int i = 0; i < intPow(2, parts.Length - 1); i++){
            ulong testSum = opperate(parts[0], parts[1], (i & 1) > 0);
            for (int j = 1; j < parts.Length - 1; j++){
                testSum = opperate(testSum, parts[j + 1], (i & intPow(2, j)) > 0);
            }

            if (testSum == sum){
                return true;
            }
        }
        
        return false;
    }
    
    public static string solve(){
        StreamReader reader = new StreamReader("../../../inputs/Day7.txt");
        string? line = reader.ReadLine();
        
        ulong sum = 0;
        
        while (line != null){
            string[] parts = line.Split(" ");
            ulong total = ulong.Parse(parts[0].Substring(0, parts[0].Length - 1));
            ulong[] numbers = new ulong[parts.Length - 1];

            for (int i = 1; i < parts.Length; i++){
                numbers[i - 1] = ulong.Parse(parts[i]);
            }

            if (testSequence(total, numbers)){
                sum += total;
            }
            
            line = reader.ReadLine();
        }
        
        return sum.ToString();
    }
}

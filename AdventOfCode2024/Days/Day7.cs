namespace AdventOfCode2024;

public class Day7
{
    enum Operation
    {
        add = 0,
        multiply = 1,
        concat = 2
    }
    static ulong opperate(ulong a, ulong b, Operation op){
        switch (op)
        {
            case Operation.add:
                return a + b;
            case Operation.multiply:
                return a * b;
            case Operation.concat:
                return ulong.Parse(a.ToString() + b.ToString());
            default:
                return 0;
        }
    }
    
    static int intPow(int x, int pow){
        int ret = 1;

        for (int i = 0; i < pow; i++){
            ret *= x;
        }

        return ret;
    }
    
    static bool testSequence(ulong sum, ulong[] parts)
    {
        Operation[] ops = new Operation[parts.Length - 1];
        for (int i = 0; i < ops.Length; i++)
        {
            ops[i] = Operation.add;
        }

        do
        {
            ulong testSum = opperate(parts[0], parts[1], ops[0]);
            for (int j = 1; j < parts.Length - 1; j++){
                testSum = opperate(testSum, parts[j + 1], ops[j]);
            }
            
            if (testSum == sum){
                return true;
            }

            for (int i = 0; i < ops.Length; i++)
            {
                ops[i] = (Operation)(((int)ops[i] + 1) % 3);
                if (ops[i] != Operation.add)
                {
                    break;
                }
            }
        }
        while(ops.Any(x => x != Operation.add));
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

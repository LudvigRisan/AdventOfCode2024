namespace AdventOfCode2024;

public class Day5
{
    struct rule
    {
        public rule(int b, int a){
            before = b;
            after = a;
        }
        
        public int before;
        public int after;
    }
    
    public static string solve()
    {
        StreamReader reader = new StreamReader("../../../inputs/Day5.txt");
        string? line = reader.ReadLine();
        
        List<rule> rules = new List<rule>();
        
        
        while (line != ""){
            string[] values = line.Split("|");
            rules.Add(new rule(int.Parse(values[0]), int.Parse(values[1])));
            line = reader.ReadLine();
        }

        line = reader.ReadLine();
        int sum = 0;
        while (line != null){
            int[] values = line.Split(",").Select(x => int.Parse(x)).ToArray();
            bool valid = true;

            for (int k = 0; k < rules.Count; k++){
                int beforeIndex = -1;
                int afterIndex = -1;

                for (int i = 0; i < values.Length; i++){
                    if (values[i] == rules[k].before){
                        beforeIndex = i;
                    }
                    else if(values[i] == rules[k].after){
                        afterIndex = i;
                    }
                }

                if (beforeIndex != -1 && afterIndex != -1 && beforeIndex > afterIndex){
                    (values[beforeIndex], values[afterIndex]) = (values[afterIndex], values[beforeIndex]);
                    k = 0;
                    valid = false;
                }
            }

            for (int i = 0; i < values.Length; i++){
                Console.Write(values[i] + ",");
            }
            
            Console.WriteLine();

            if (!valid){
                sum += values[values.Length / 2];
            }
            
            line = reader.ReadLine();
        }
        
        return sum.ToString();
    }
}
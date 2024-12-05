namespace AdventOfCode2024;

public class Day4_2
{
    static List<string> input = new List<string>();
    static List<List<bool>> print = new List<List<bool>>();

    static bool search(int yPos, int xPos){
        int mCount = 0;
        int sCount = 0;

        for (int i = -1; i <= 1; i += 2){
            for (int j = -1; j <= 1; j += 2){
                if (input[yPos + i][xPos + j] == 'M'){
                    mCount++;
                } 
                else if (input[yPos + i][xPos + j] == 'S'){
                    sCount++;
                }
            }
        }
        return mCount == 2 && sCount == 2 && input[yPos + 1][xPos + 1] != input[yPos - 1][xPos - 1];
    }

    static void addPrint(int yPos, int xPos){
        print[yPos][xPos] = true;

        for (int i = -1; i <= 1; i += 2){
            for (int j = -1; j <= 1; j += 2){
                print[yPos + i][xPos + j] = true;
            }
        }
    }
    
    public static string solve(){
        StreamReader reader = new StreamReader("../../../inputs/Day4.txt");

        string line = reader.ReadLine();

        while (line != null){
            input.Add(line);
            print.Add(new List<bool>());

            for (int i = 0; i < line.Length; i++){
                print.Last().Add(false);
            }
            line = reader.ReadLine();
        }

        int hits = 0;

        for (int i = 1; i < input.Count - 1; i++){
            for (int j = 1; j < input[i].Length - 1; j++){
                if (input[i][j] == 'A'){
                    if (!print[i][j] && search(i, j)){
                        hits++;
                        addPrint(i, j);
                    }
                }
            }
        }
        
        for (int i = 0; i < print.Count; i++){
            for (int j = 0; j < print[i].Count; j++){
                Console.Write(print[i][j] ? input[i][j] : ".");
            }
            Console.WriteLine();
        }
        
        return hits.ToString();
    }
}

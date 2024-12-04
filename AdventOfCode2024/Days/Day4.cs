namespace AdventOfCode2024;

public class Day4
{
    static List<string> input = new List<string>();
    static List<List<bool>> print = new List<List<bool>>();
    static string searchText = "XMAS";
    static bool search(int xPos, int yPos, int xDir, int yDir){
        for (int i = 1; i < searchText.Length; i++){
            xPos += xDir;
            yPos += yDir;

            if (yPos < 0 || 
                yPos >= input.Count || 
                xPos < 0 || 
                xPos >= input[yPos].Length ||
                input[yPos][xPos] != searchText[i]){
                return false;
            }
        }
        return true;
    }
    
    static void fill(int xPos, int yPos, int xDir, int yDir){
        print[yPos][xPos] = true;
        for (int i = 1; i < searchText.Length; i++){
            xPos += xDir;
            yPos += yDir;
            
            print[yPos][xPos] = true;
        }
    }

    public static string solve(){
        StreamReader reader = new StreamReader("../../../inputs/Day4.txt");
        
        string line = reader.ReadLine();

        while (line != null){
            input.Add(line);
            // print.Add(new List<bool>());

            // for (int i = 0; i < line.Length; i++){
                // print.Last().Add(false);
            // }
            line = reader.ReadLine();
        }
        
        int hits = 0;
        
        for (int i = 0; i < input.Count; i++){
            for (int j = 0; j < input[i].Length; j++){
                if (input[i][j] == 'X'){
                    for (int k = -1; k <= 1; k++){
                        for (int l = -1; l <= 1; l++){
                            if (search(j, i, k, l)){
                                hits++;
                                // fill(j, i, k, l);
                            }
                        }
                    }
                }
            }
        }

        // for (int i = 0; i < print.Count; i++){
        //     for (int j = 0; j < print.Count; j++){
        //         Console.Write(print[i][j] ? input[i][j] : ".");
        //     }
        //     Console.WriteLine();
        // }
        
        return hits.ToString();
    }
}

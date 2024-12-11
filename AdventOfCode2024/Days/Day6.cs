namespace AdventOfCode2024;

public class Day6
{

    enum Direction
    {
        up = 1,
        right = 2,
        down = 4,
        left = 8,
    }

    static bool willLoop(bool[][] board, int posX, int posY, int addY, int addX){
        bool[][] boardClone = board.Select(x => x.Select(y => y).ToArray()).ToArray();
        boardClone[addY][addX] = true;
        
        short[][] traversal =  new short[boardClone.Length][];

        for (int i = 0; i < boardClone.Length; i++){
            traversal[i] = new short[boardClone[i].Length];
        }
        
        Direction dir = Direction.up;

        int stepCount = 0;
        
        while (posX >= 0 && posX < boardClone[0].Length && posY >= 0 && posY < boardClone.Length){
            if ((traversal[posY][posX] & (int)dir) > 0){
                
                return true;
            }
            
            traversal[posY][posX] += (short)dir;
            bool turned = false;
            switch (dir){
                case Direction.up: 
                    if (posY != 0 && boardClone[posY - 1][posX]){
                        dir = Direction.right;
                        turned = true;
                    }
                    break;
                case Direction.right:
                    if (posX != boardClone[posY].Length - 1 && boardClone[posY][posX + 1]){
                        dir = Direction.down;
                        turned = true;
                    }
                    break;
                case Direction.down:
                    if (posY != boardClone.Length - 1 && boardClone[posY + 1][posX]){
                        dir = Direction.left;
                        turned = true;
                    }
                    break;
                case Direction.left:
                    if (posX != 0 && boardClone[posY][posX - 1]){
                        dir = Direction.up;
                        turned = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!turned){
                
                switch (dir){
                    case Direction.up:
                        posY--;
                        break;
                    case Direction.right:
                        posX++;
                        break;
                    case Direction.down:
                        posY++;
                        break;
                    case Direction.left:
                        posX--;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            stepCount++;
        }
        // for (int i = 0; i < board.Length; i++){
        //     for (int j = 0; j < board.Length; j++){
        //         if (board[i][j]){
        //             Console.Write("#");
        //         }
        //         else if (i == addY && j == addX){
        //             Console.Write("0");
        //         }
        //         else{
        //             switch (traversal[i][j]){
        //                 case 0:
        //                     Console.Write(" ");
        //                     break;
        //                 case 1:
        //                     Console.Write("^");
        //                     break;
        //                 case 2:
        //                     Console.Write(">");
        //                     break;
        //                 case 3:
        //                     Console.Write("\u2514");
        //                     break;
        //                 case 4:
        //                     Console.Write("V");
        //                     break;
        //                 case 5:
        //                     Console.Write("|");
        //                     break;
        //                 case 6:
        //                     Console.Write("\u250c");
        //                     break;
        //                 case 7:
        //                     Console.Write("\u251c");
        //                     break;
        //                 case 8:
        //                     Console.Write("<");
        //                     break;
        //                 case 9:
        //                     Console.Write("\u2518");
        //                     break;
        //                 case 10:
        //                     Console.Write("\u2500");
        //                     break;
        //                 case 11:
        //                     Console.Write("\u2534");
        //                     break;
        //                 case 12:
        //                     Console.Write("\u2510");
        //                     break;
        //                 case 13:
        //                     Console.Write("\u2524");
        //                     break;
        //                 case 14:
        //                     Console.Write("\u252c");
        //                     break;
        //                 case 15:
        //                     Console.Write("\u253c");
        //                     break;
        //                 default:
        //                     Console.Write("?");
        //                     break;
        //             }
        //         }
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
        return false;
    }
    
    public static string solve()
    {
        StreamReader reader = new StreamReader("../../../inputs/Day6.txt");
        string[] input = reader.ReadToEnd().Split("\r\n");

        bool[][] board = input.Select(x => x.Select(y => y == '#').ToArray()).ToArray();
        bool[][] originPath = new bool[board.Length][];
        
        Direction dir = Direction.up;
        int posX = 0;
        int posY = 0;

        for (int i = 0; i < originPath.Length; i++){
            originPath[i] = new bool[board[i].Length];
            if(input[i].Contains('^'))
            {
                posY = i;
                posX = input[i].IndexOf('^');
            }
        }

        int originX = posX;
        int originY = posY;
        
        while (posX >= 0 && posX < board[0].Length && posY >= 0 && posY < board.Length){
            originPath[posY][posX] = true;

            switch (dir){
                case Direction.up: 
                    if (posY != 0 && board[posY - 1][posX]){
                        dir = Direction.right;
                    }
                    break;
                case Direction.right:
                    if (posX != board[posY].Length - 1 && board[posY][posX + 1]){
                        dir = Direction.down;
                    }
                    break;
                case Direction.down:
                    if (posY != board.Length - 1 && board[posY + 1][posX]){
                        dir = Direction.left;
                    }
                    break;
                case Direction.left:
                    if (posX != 0 && board[posY][posX - 1]){
                        dir = Direction.up;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            switch (dir){
                case Direction.up:
                    posY--;
                    break;
                case Direction.right:
                    posX++;
                    break;
                case Direction.down:
                    posY++;
                    break;
                case Direction.left:
                    posX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // for (int i = 0; i < board.Length; i++){
        //     for (int j = 0; j < board[i].Length; j++){
        //         Console.Write(originPath[i][j] ? "*" : board[i][j] ? "#" : ".");
        //     }
        //     Console.WriteLine();
        // }

        int loops = 0;

        for (int i = 0; i < board.Length; i++){
            for (int j = 0; j < board[i].Length; j++){
                if (originPath[i][j] && !(i == originY && j == originX) && willLoop(board, originX, originY, i, j )){
                    loops++;
                }
            }
        }
        
        
        return loops.ToString();
    }
}
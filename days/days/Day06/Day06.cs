using System.Numerics;

namespace days;

public class Day06
{
    /*
     Simulate simple guard pathfinding. He goes forward or turn right. 
     If he goes back to his starting point - program stops
     Count total sqares of his patrol (including starting one)
    */
    
    private static List<List<char>> Lines = Helper.GetCharMatrix("../../../TestData.txt");
    private static List<Vector2> Obstructions = [];
    private static Vector2 GuardPos; // Y X
    private static int points = 1;
    private static int position = 0;
    
    public static void GetAnswer()
    {
        
        
        /*for (int i = 0; i < Lines.Count; i++)
        {
            for (int j = 0; j < Lines[i].Count; j++)
            {*/
                var tempLines = new List<List<char>>();
                foreach (var l in Lines)
                {
                    tempLines.Add(l);
                }

                /*if (tempLines[i][j] != '^' && tempLines[i][j] != '#')
                {
                    tempLines[i][j] = '#';
                }
                else
                {
                    break;
                }*/
                
                InitializeData();
                var key = ConsoleKey.A;
                var startingPos = new Vector2();

                startingPos.X = GuardPos.X;
                startingPos.Y = GuardPos.Y;

                int n = 0;
                while (true)
                {
                    n++;
                    key = key switch
                    {
                        ConsoleKey.W => ConsoleKey.D,
                        ConsoleKey.D => ConsoleKey.S,
                        ConsoleKey.S => ConsoleKey.A,
                        ConsoleKey.A => ConsoleKey.W,
                        _ => key
                    };

                    if (GuardPos.X == startingPos.X && GuardPos.Y == startingPos.Y && n > 2)
                    {
                        position++;
                        break;
                    }

                    while (true)
                    {
                        //ShowData();
                        //Thread.Sleep(10);
                        //Console.WriteLine(startingPos.X.ToString(), startingPos.Y);
                        
                        int playerX = (int)GuardPos.X;
                        int playerY = (int)GuardPos.Y;

                        if ((key == ConsoleKey.D && playerY >= tempLines.Count - 1) ||
                            (key == ConsoleKey.A && playerY <= 0) ||
                            (key == ConsoleKey.W && playerX <= 0) ||
                            (key == ConsoleKey.S && playerX >= tempLines[0].Count - 1))
                        {
                            Console.WriteLine(points);
                            Environment.Exit(0);
                        }
                    
                        if (key == ConsoleKey.D && playerY < tempLines.Count - 1)
                        {
                            if (tempLines[playerX][playerY + 1] != '#')
                            {
                                if (tempLines[playerX][playerY + 1] == '.') points++;
                                tempLines[playerX][playerY + 1] = 'X'; // Lines update positions in reverse
                                GuardPos = new Vector2(playerX, playerY + 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (key == ConsoleKey.A && playerY > 0)
                        {
                            if (tempLines[playerX][playerY - 1] != '#')
                            {
                                if (tempLines[playerX][playerY - 1] == '.') points++;
                                tempLines[playerX][playerY - 1] = 'X'; // Lines update positions in reverse
                                GuardPos = new Vector2(playerX, playerY - 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (key == ConsoleKey.W && playerX > 0)
                        {
                            if (tempLines[playerX - 1][playerY] != '#')
                            {
                                if (tempLines[playerX - 1][playerY] == '.') points++;
                                tempLines[playerX - 1][playerY] = 'X'; // Lines update positions in reverse
                                GuardPos = new Vector2(playerX - 1, playerY);
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                        else if (key == ConsoleKey.S && playerX < tempLines[0].Count - 1)
                        {
                            if (tempLines[playerX + 1][playerY] != '#')
                            {
                                if (tempLines[playerX + 1][playerY] == '.') points++;
                                tempLines[playerX + 1][playerY] = 'X'; // Lines update positions in reverse
                                GuardPos = new Vector2(playerX + 1, playerY);
                            }
                            else
                            {
                                break;
                            }
                        }
                        else break;
                    }
                }
            /*}
        }*/
        
        Console.WriteLine(points);
    }

    private static void ShowData()
    {
        Console.Clear();
        Console.WriteLine($"X: {GuardPos.X} Y: {GuardPos.Y}, Points: {points}");
        foreach (var l in Lines)
        {
            foreach (var c in l)
            {
                Console.Write(c);
            }
            Console.WriteLine("");
        }
    }

    private static void InitializeData()
    {
        for (int i = 0; i < Lines.Count; i++)
        {
            for (int j = 0; j < Lines[i].Count; j++)
            {
                switch (Lines[i][j])
                {
                    case '^':
                        GuardPos = new Vector2(i, j);
                        break;
                    case '#':
                        Obstructions.Add(new Vector2(i, j));
                        break;
                }
            }
        }
    }
}
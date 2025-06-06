namespace advent._2024.Day06;

public class Day06_2
{
    // brute force
    
    private static Vector2Int MoveVector = new Vector2Int(0, -1);
    private static Vector2Int GuardPosition;
    private static List<List<char>> Map = Helper.GetCharMatrix("../../../Day06/Day06.txt");

    private static int points = 1;
    private static int possibilities = 0;

    public static void GetAnswer()
    {
        InitializeData();
        
        int width = Map[0].Count;
        int height = Map.Count;

        int startingX = GuardPosition.X;
        int startingY = GuardPosition.Y;
        
        List<List<char>> alternateMap = new List<List<char>>();
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //Console.WriteLine($"--- Testing: blockade placed in x:{j} y:{i}---");
                
                GuardPosition.X = startingX;
                GuardPosition.Y = startingY;
                MoveVector = new Vector2Int(0, -1);
                
                alternateMap = new List<List<char>>();
                foreach (var m in Map)
                {
                    List<char> foo = new List<char>();
                    foreach (var n in m) foo.Add(n);
                    alternateMap.Add(foo);
                }

                if (alternateMap[i][j] == '.')
                {
                    alternateMap[i][j] = '#';
                }
                else
                {
                    //Console.WriteLine(" Break: cannot place obstruction here!");
                    continue;
                }

                int steps = 0;
                
                while (true)
                {
                    //Console.WriteLine($"        guard is at x: {GuardPosition.X}, {GuardPosition.Y} moving {MoveVector.X}, {MoveVector.Y}");
                    
                    steps++;
                    if (GuardPosition.X + MoveVector.X >= 0 && GuardPosition.X + MoveVector.X < width && GuardPosition.Y + MoveVector.Y >= 0 && GuardPosition.Y + MoveVector.Y < height)
                    {
                        if (alternateMap[GuardPosition.Y + MoveVector.Y][GuardPosition.X + MoveVector.X] != '#')
                        {
                            GuardPosition.X += MoveVector.X;
                            GuardPosition.Y += MoveVector.Y; 
                        }
                        else
                        {
                            ChangeDirection();
                        }

                        if (steps > 16000)
                        {
                            possibilities++;
                            break;
                        }
                    }
                    else
                    {
                        //Console.WriteLine($" Break: Guard has escaped the map");
                        break;
                    }
                }
            }
        }
        
        
        
        Console.WriteLine($"Total points: {points}");
        Console.WriteLine($"Total possibilities: {possibilities}");
    }

    public static void ChangeDirection()
    {
        if (MoveVector.X == 0)
        {
            MoveVector.X = MoveVector.Y * -1;
            MoveVector.Y = 0;
        }
        else if (MoveVector.Y == 0)
        {
            MoveVector.Y = MoveVector.X;
            MoveVector.X = 0;
        }
        
        //Console.WriteLine($"The new direction is {MoveVector.X}, {MoveVector.Y}");
    }

    public static void InitializeData()
    {
        int width = Map[0].Count;
        int height = Map.Count;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Map[j][i] == '^')
                {
                    GuardPosition = new Vector2Int(i, j);
                    Console.WriteLine($"Guard located at: {i}, {j}");
                }
            }
        }
    }
}

public class Vector2Int
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2Int(int x, int y)
    {
        X = x;
        Y = y;
    }
}
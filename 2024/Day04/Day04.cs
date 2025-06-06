namespace advent._2024.Day04;

public class Day04
{
    // horizontal
    // vertical
    // backwards either way
    // overlapping
    
    // search for xmas or samx horizontal and vertical
    // look only down and right the matrix to avoid multiplication of searches
    // same to diagonal, look only to right down and left down diagonal

    public static void GetAnswer()
    {
        var lines = Helper.GetStringArray("../../../Data/Day04.txt");
        int sum = 0;
        
        List<string> words = new List<string>() { "XMAS", "SAMX" };
        
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                foreach (var w in words)
                {
                    if (lines[i][j] == w[0])
                    {
                        if (j + 3 < lines[i].Length && (lines[i][j + 1] == w[1] && lines[i][j + 2] == w[2] && lines[i][j + 3] == w[3]))
                            sum++;
                        
                        if (i + 3 < lines.Count && (lines[i + 1][j] == w[1] && lines[i + 2][j] == w[2] && lines[i + 3][j] == w[3]))
                            sum++;
                        
                        if (i + 3 < lines.Count && j + 3 < lines[i].Length && (lines[i + 1][j + 1] == w[1] && lines[i + 2][j + 2] == w[2] && lines[i + 3][j + 3] == w[3]))
                            sum++;
                        
                        if (i + 3 < lines.Count && j >= 3 && (lines[i + 1][j - 1] == w[1] && lines[i + 2][j - 2] == w[2] && lines[i + 3][j - 3] == w[3]))
                            sum++;
                    }
                }
            }
        }
        
        Console.WriteLine(sum);
    }
    
    public static void GetAnswerPartTwo()
    {
        var lines = Helper.GetStringArray("../../../Day04/Day04.txt");
        int sum = 0;
        
        List<string> words = new List<string>() { "MAS", "SAM" };
        
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                foreach (var w in words)
                {
                    if ((i + 2 < lines.Count && j + 2 < lines[i].Length) && lines[i][j] == w[0])
                    {
                        if (lines[i + 1][j + 1] == w[1] && lines[i + 2][j + 2] == w[2])
                        {
                            if ((lines[i][j + 2] == w[0] && lines[i + 2][j] == w[2]) 
                                || (lines[i][j + 2] == w[2] && lines[i + 2][j] == w[0]))
                            {
                                sum++;
                            }
                        }
                    }
                }
            }
        }
        
        Console.WriteLine(sum);
    }
}
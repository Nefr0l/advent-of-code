namespace day01;

internal class Program
{
    /*
     * 1. Stworzyć dwie listy liczb
     * 2. Posortować listy rosnąco
     * 3. Dodać różnice między liczbami po kolei
     */
    
    static void Main()
    {
        int sum = 0;
        string path = @"/ssd1/my-stuff/aoc-2024/day-01-v1/day-01-v1/data.txt";
        string[] lines = File.ReadAllLines(path);
        
        List<string> left = new List<string>();
        List<string> right = new List<string>();

        foreach (var l in lines)
        {
            left.Add(l.Substring(0, 5));
            right.Add(l.Substring(8, 5));
        }
        
        left.Sort();
        right.Sort();

        for (int i = 0; i < left.Count; i++)
        {
            int x = int.Parse(left[i]) - int.Parse(right[i]);
            if (x < 0) x *= -1;
            sum += x;
        }
        
        Console.WriteLine(sum);

    }
}
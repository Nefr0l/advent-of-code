namespace day_01_v2;

internal class Program
{
    static void Main(string[] args)
    {
        string path = "/ssd1/my-stuff/aoc-2024/day-01-v2/day-01-v2/data.txt";
        string[] lines = File.ReadAllLines(path);
        
        List<int> left = new(), right = new();
        
        foreach (var l in lines)
        {
            left.Add(int.Parse(l.Substring(0, 5)));
            right.Add(int.Parse(l.Substring(8, 5)));
        }
        
        left.Sort();
        right.Sort();

        int sum = 0, leftIterator = 0, rightIterator = 0;
        while (leftIterator < left.Count && rightIterator < right.Count)
        {
            if (left[leftIterator] == right[rightIterator])
            {
                sum += left[leftIterator];
            }
            else if (left[leftIterator] <= right[rightIterator])
            {
                leftIterator++;
                continue;
            }
            rightIterator++;
        }
        
        Console.WriteLine(sum);
    }
}
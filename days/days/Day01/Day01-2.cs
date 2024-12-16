namespace days;

public class Day01_2
{
    public static void GetAnswer()
    {
        string path = "../../../Day01/Day01.txt";
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
namespace days;

public class Day07
{
    private static Dictionary<long, List<long>> Data = [];
    private static long sum = 0, count = 0;
    
    public static void GetAnswer()
    {
        GetData();

        foreach (var d in Data)
        {
            int possibilities = int.Parse(Math.Pow(2, d.Value.Count - 1).ToString());
            Console.WriteLine("Possibilities: " + possibilities);

            bool isPossible = IsPossible(1, d.Value.Count - 1, d.Value, d.Key);
            Console.WriteLine(isPossible);

            if (isPossible)
            {
                count++;
                sum += d.Key;
            }
        }
        
        Console.WriteLine(count);
        Console.WriteLine(sum);
    }

    public static bool IsPossible(int n, int slots, List<long> numbers, long finalNumber)
    {
        if (n > slots)
            return false;
        
        if (numbers[0] * numbers[1] == finalNumber || numbers[0] + numbers[1] == finalNumber)
            return true;

        List<long> foo = numbers.ToList();
        foo[0] *= foo[1];
        foo.RemoveAt(1);
        
        List<long> foo2 = numbers.ToList();
        foo2[0] += foo2[1];
        foo2.RemoveAt(1);
        
        return IsPossible(n + 1, slots, foo2, finalNumber) || IsPossible(n + 1, slots, foo, finalNumber);
    }

    public static void GetData()
    {
        var temp = Helper.GetStringArray("../../../Day07/Data.txt");
        //var temp = Helper.GetStringArray("../../../TestData.txt");
        
        foreach (var t in temp)
        {
            long key = 0;
            List<string> values = [];
            List<long> intValues = [];

            int separatorIndex = t.IndexOf(':');
            key = long.Parse(t.Substring(0, separatorIndex));
            values = t.Substring(separatorIndex + 2).Split(' ').ToList();
            intValues.AddRange(values.Select(long.Parse));
            
            Data.Add(key, intValues);
            
            /* Debug only
             Console.Write($"Added new record. Key: {key} |");
            foreach (var i in intValues) Console.Write(" " + i);
            Console.WriteLine("");
            */
        }
    }
}
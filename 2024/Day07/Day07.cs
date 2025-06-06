namespace advent._2024.Day07;

public class Day07
{
    private static Dictionary<nuint, List<nuint>> Data = [];
    private static nuint sum = 0, count = 0;
    
    public static void GetAnswer()
    {
        GetData();

        foreach (var d in Data)
        {
            bool isPossible = IsPossible(1, d.Value.Count-1, d.Value, d.Key);
            
            //Console.WriteLine("");
            //Console.WriteLine(isPossible);

            if (isPossible)
            {
                count++;
                sum += d.Key;
            }
            
            Console.WriteLine(d.Key + " |  Sum: " + sum + " | Added: " + isPossible);
        }
        
        Console.WriteLine(count);
        Console.WriteLine(sum);
    }

    public static bool IsPossible(long n, long slots, List<nuint> numbers, nuint finalNumber)
    {
        if (n > slots)
            return false;
        
        if (((numbers[0] * numbers[1] == finalNumber) || (numbers[0] + numbers[1] == finalNumber) || (nuint.Parse(numbers[0] + numbers[1].ToString()) == finalNumber)) && n == slots)
            return true;

        List<nuint> foo = numbers.ToList();
        foo[0] *= foo[1];
        foo.RemoveAt(1);
        
        List<nuint> foo2 = numbers.ToList();
        foo2[0] += foo2[1];
        foo2.RemoveAt(1);

        List<nuint> foo3 = numbers.ToList();
        foo3[0] = nuint.Parse(foo3[0] + foo3[1].ToString());
        foo3.RemoveAt(1);
        //Console.Write(foo3[0] + ", ");
        
        return IsPossible(n + 1, slots, foo2, finalNumber) || IsPossible(n + 1, slots, foo, finalNumber) || IsPossible(n+1, slots, foo3, finalNumber);
    }

    public static void GetData()
    {
        var temp = Helper.GetStringArray("../../../Day07/Data.txt");
        //var temp = Helper.GetStringArray("../../../TestData.txt");
        
        foreach (var t in temp)
        {
            nuint key = 0;
            List<string> values = [];
            List<nuint> intValues = [];

            int separatorIndex = t.IndexOf(':');
            key = nuint.Parse(t.Substring(0, separatorIndex));
            values = t.Substring(separatorIndex + 2).Split(' ').ToList();
            intValues.AddRange(values.Select(nuint.Parse));
            
            Data.Add(key, intValues);
        }
    }
}
using System.Text.RegularExpressions;

namespace days.Days;

public class Day03
{
    public static void GetAnswer()
    {
        var text = Helper.GetString("../../../Data/TestData.txt");
        
        var mulsMatches = Regex.Matches(text, "mul\\(\\d+,\\d+\\)");
        var muls = mulsMatches.Select(m => m.Value).ToList();

        int sum = 0;
        
        foreach (var mul in muls)
        {
            string m = String.Join("", mul.Split('@','(' ,')', 'm', 'u', 'l'));
            var matches = Regex.Matches(m, @"\d+");
            var result = matches.Take(2).Select(m => m.Value).ToList();

            int x = int.Parse(result[0]);
            int y = int.Parse(result[01]);

            sum += x * y;
            
            Console.WriteLine(m);
        }
        
        Console.WriteLine(sum);
    }

    public static void GetAnswerPartTwo()
    {
        string text = Helper.GetString("../../../Data/Day03.txt");

        var toRemove = Regex.Matches(text, "don't\\(\\).*?do\\(\\)");
        var listToRemove = toRemove.Select(m => m.Value).ToList();

        Console.WriteLine(listToRemove.Count);
        for (int i = 0; i < listToRemove.Count; i++)
        {
            string toReplace2 = listToRemove[i].ToString();

            if (toReplace2 != String.Empty)
            {
                Console.WriteLine("Replacing " + toReplace2);
                text = text.Replace(toReplace2, "");
            }
        }
        
        var mulsMatches = Regex.Matches(text, "mul\\(\\d+,\\d+\\)");
        var muls = mulsMatches.Select(m => m.Value).ToList();

        int sum = 0;

        for (var i = 0; i < muls.Count; i++)
        {
            var mul = muls[i];
            
            var matches = Regex.Matches(mul, @"\d+");
            var result = matches.Take(2).Select(m => m.Value).ToList();

            int x = int.Parse(result[0]);
            int y = int.Parse(result[1]);
            
            sum += x * y;
            
            Console.WriteLine(mul);
        }
        
        Console.WriteLine(sum);
    }
}
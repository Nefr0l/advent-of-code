namespace days.Day05;

public static class Day05
{
    private static List<string> Lines = Helper.GetStringArray("../../../Day05/Day05.txt");
    private static List<List<int>> Rules = []; // index 0 is left num, index 1 is right num
    private static List<List<int>> Pages = [];
    private static List<List<int>> InvalidPages = [];
    
    public static void GetAnswer()
    {
        GetData();
        var sum = 0;

        // Check valid and invalid pages - part one
        for (var i = 0; i < Pages.Count; i++)
        {
            var isValid = true;
            var page = Pages[i];
            var appliedRules = Rules.Where(e => page.Contains(e[0]) && page.Contains(e[1])).ToList();

            foreach (var rule in appliedRules)
            {
                int leftIndex = page.IndexOf(rule[0]);
                int rightIndex = page.IndexOf(rule[1]);

                if (rightIndex <= leftIndex && (leftIndex != 0 || rightIndex != 0))
                {
                    isValid = false;
                    break;
                }
            }
            
            if (isValid)
            {
                sum+= Pages[i][Pages[i].Count / 2];
            }
            else
            {
                InvalidPages.Add([]);
                foreach (var num in page)
                {
                    InvalidPages[^1].Add(num);
                }
            }
        }
        Console.WriteLine(sum);

        // Sort invalid pages - part two
        int sum2 = 0;
        Dictionary<int, int> Numbers = []; // key - x number, value - number of numbers it has to be behind
        
        for (int i = 0; i < InvalidPages.Count; i++)
        {
            var page = InvalidPages[i];
            var appliedRules = Rules.Where(e => page.Contains(e[0]) && page.Contains(e[1])).ToList();
            Numbers.Clear();
            
            foreach (var p in page)
            {
                sum = 0;
                foreach (var rule in appliedRules)
                    if (rule[0] == p) sum++;
                
                Numbers.Add(p, sum);
            }
            
            foreach (var n in Numbers)
                Console.WriteLine(n.Key + ", Pos:" + n.Value);
            
            sum2 += Numbers.First(e => e.Value == Numbers.Count / 2).Key;
        }
        
        Console.WriteLine(sum2);
    }

    private static void GetData()
    {
        int i = 0, j = 0;

        while (Lines[i].Trim() != String.Empty)
        {
            var nums = Lines[i].Split('|');
            Rules.Add(new List<int> {int.Parse(nums[0]) , int.Parse(nums[1])} );
            Console.WriteLine(Rules[i][0] + "|" + Rules[i][1]);
            i++;
        }

        i++;

        while (i < Lines.Count)
        {
            var nums = Lines[i].Split(',');
            Pages.Add(new List<int>());

            foreach (var n in nums)
                Pages[j].Add(int.Parse(n));
            
            i++;
            j++;
        }

        Console.WriteLine(Pages.Count);
    }
}
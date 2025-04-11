namespace days;

public class Helper
{
    public static List<List<int>> GetMatrix(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var list = new List<List<char>>();
        var finalList = new List<List<int>>();

        foreach (var l in lines)
        {
            list.Add(l.ToCharArray().ToList());
        }

        for (int i = 0; i < list.Count; i++)
        {
            List<int> numbersInLine = [];
            string n = String.Empty;
            
            for (int j = 0; j < list[i].Count; j++)
            {
                if (list[i][j] == ' ' && n != string.Empty)
                {
                    numbersInLine.Add(int.Parse(n));
                    n = String.Empty;
                }
                else if (int.TryParse(list[i][j].ToString(), out int x))
                {
                    n += x.ToString();
                }
            }
            
            numbersInLine.Add(int.Parse(n));
            finalList.Add(numbersInLine);
        }

        return finalList;
    }

    public static List<string> GetStringArray(string filePath)
    {
        List<string> lines = File.ReadAllLines(filePath).ToList();
        return lines;
    }
    
    public static List<List<char>> GetCharMatrix(string filePath)
    {
        List<string> lines = File.ReadAllLines(filePath).ToList();
        List<List<char>> temp = new List<List<char>>();

        foreach (var t in lines)
        {
            temp.Add(t.ToCharArray().ToList());
        }

        return temp;
    }
    
    public static string GetString(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}
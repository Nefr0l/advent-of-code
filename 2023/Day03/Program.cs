namespace advent._2023.Day03;

internal class Program2
{
    private static string[] lines = File.ReadAllLines(@"G:\Projekty\C#\Advent of code\day-03\day-03\Values");
    
    public static void Main2()
    {
        int sum = 0;

        for (int i = 0; i < lines.Count(); i++)
        {
            sum += SumCorrectNumbers(ListNumbers(lines[i]), i);
            Console.WriteLine(sum);
        }
        Console.WriteLine(sum); 
        
    }

    private static List<Number> ListNumbers(string line)
    {
        var list = new List<Number>();
        char[] chars = line.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsNumber(chars[i]))
            {
                var n = new Number(int.Parse(chars[i].ToString()), new List<int>());
                n.indexes.Add(i);
                i++;
                
                while (i < chars.Length && char.IsNumber(chars[i]))
                {
                    n.value = n.value * 10 + int.Parse(chars[i].ToString());
                    n.indexes.Add(i);
                    i++;
                }
                list.Add(n);
            }
        }
        return list;
    }

    private static int SumCorrectNumbers(List<Number> oldList, int line)
    {
        var newList = new List<Number>();
        char[] chars = lines[line].ToCharArray();
        int sum = 0;

        for (int i = 0; i < oldList.Count; i++)
        {
            for (int j = 0; j < oldList[i].indexes.Count; j++)
            {
                var n = oldList[i];
                var width = chars.Length - 1;
                var height = lines.Length - 1;

                if (
                    (line > 0 && n.indexes[j] > 0 && CheckSymbol(lines[line-1][n.indexes[j]-1])) ||
                    (line > 0 && CheckSymbol(lines[line-1][n.indexes[j]])) ||
                    (line > 0 && n.indexes[j] < width && CheckSymbol(lines[line-1][n.indexes[j]+1])) ||
                    
                    (n.indexes[j] > 0 && CheckSymbol(lines[line][n.indexes[j]-1])) ||
                    (CheckSymbol(lines[line][n.indexes[j]])) ||
                    (n.indexes[j] < width && CheckSymbol(lines[line][n.indexes[j]+1])) ||
                    
                    (line < height && n.indexes[j] > 0 && CheckSymbol(lines[line+1][n.indexes[j]-1])) ||
                    (line < height && CheckSymbol(lines[line+1][n.indexes[j]])) ||
                    (line < height && n.indexes[j] < width && CheckSymbol(lines[line+1][n.indexes[j]+1]))
                    )
                {
                    newList.Add(oldList[i]);
                    sum += oldList[i].value;
                    break;
                }
            }
        }
        return sum;
    }

    private static bool CheckSymbol(char c)
    {
        if (c == '.' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0') 
            return false;
        
        return true;
    }
}

/*
KROKI:
Sprawdzenie jednej linijki:
1. Zebranie numerów i ich indeksów i dodanie ich do ogólnej listy numerów
2. Sprawdzenie używając indeksów czy dany numer sąsiaduje z symbolami i dodanie go do drugiej listy numerów
3. Zsumowanie numerów i zwrócenie ich
*/
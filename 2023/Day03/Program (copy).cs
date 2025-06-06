namespace advent._2023.Day03;

internal class Program3
{
    private static string[] lines = File.ReadAllLines(@"G:\Projekty\Advent of code\day-03-2\day-03\Values");
    private static List<Position> gears = new();

    public static void Main2()
    {
        for (int i = 0; i < lines.Length; i++)
            CheckLine(i);

        int sum = 0;
        foreach (var g in gears)
            sum += CheckGear(g.line, g.index);
        
        Console.WriteLine(sum);
    }

    // Dodaje do listy * wszystkie takie znaki w danej linijce
    private static void CheckLine(int line)
    {
        char[] chars = lines[line].ToCharArray();

        for (int i = 0; i < chars.Length; i++)
            if (chars[i] == '*')
                gears.Add(new Position(line, i));
    }

    // Sprawdza czy * na danej pozycji ma dwa numery przylegające do niego, jeśli tak - pomnożenie ichg przez siebie
    private static int CheckGear(int line, int index)
    {
        char[] chars = lines[line].ToCharArray();

        var numbersAbove = ListNumbers(line - 1);
        var numbers = numbersAbove.Concat(ListNumbers(line)).Concat(ListNumbers(line + 1)).ToList();
        var positions = new List<Position>();
        var abutNumbers = new List<int>();

        int height = lines.Length - 1;
        int width = chars.Length - 1;

        if (line > 0 && index > 0) positions.Add(new Position(line - 1, index - 1));
        if (line > 0) positions.Add(new Position(line - 1, index));
        if (line > 0 && index < width) positions.Add(new Position(line - 1, index + 1));
        if (index > 0) positions.Add(new Position(line, index - 1));
        if (index < width) positions.Add(new Position(line, index + 1));
        if (line < height && index > 0) positions.Add(new Position(line + 1, index - 1));
        if (line < height) positions.Add(new Position(line + 1, index));
        if (line < height && index < width) positions.Add(new Position(line + 1, index + 1));

        foreach (var pos in positions)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var indexes = numbers[i].indexes;
                if ((indexes[0] == pos.index || (indexes.Count > 1 && indexes[1] == pos.index) || (indexes.Count > 2 && indexes[2] == pos.index)) && numbers[i].line == pos.line)
                {
                    abutNumbers.Add(numbers[i].value);
                    numbers.Remove(numbers[i]);
                }
            }
        }

        if (abutNumbers.Count != 2) return 0;
        return abutNumbers[0] * abutNumbers[1];
    }

    // Zwraca listę wszystkich numerów w danej linijce
    private static List<Number2> ListNumbers(int line)
    {
        var list = new List<Number2>();
        char[] chars = lines[line].ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsNumber(chars[i]))
            {
                var n = new Number2(int.Parse(chars[i].ToString()), new List<int>(), line);
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
}
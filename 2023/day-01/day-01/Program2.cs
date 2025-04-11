using System;
using System.Collections.Generic;
using System.IO;

namespace day_01;

internal class Program2
{
    private static int sum;

    public static void Main(string[] args) {
        var path = @"G:\Projekty\C#\Advent of code\day-01\day-01\Values";
        var lines = File.ReadAllLines(path);

        Console.WriteLine(ReturnNumber(lines[2]));

        foreach (var line in lines) 
            sum += ReturnNumber(line);
        
        Console.WriteLine(sum);
    }

    private static int ReturnNumber(string sentence) {
        var numbers = new List<int>();
        var chars = sentence.ToCharArray();

        for (var i = 0; i < chars.Length; i++) {
            if (char.IsNumber(chars[i]))
                numbers.Add(int.Parse(chars[i].ToString()));

            for (var j = 0; j < chars.Length - i + 1; j++) {
                var text = new string(chars, i, j);

                var num = NumFromText(text);
                if (num != 0)
                    numbers.Add(num);
            }
        }

        foreach (var n in numbers)
            Console.WriteLine(n);

        return numbers[0] * 10 + numbers[numbers.Count - 1];
    }

    private static int NumFromText(string sentence) {
        switch (sentence.ToLower()) {
            case "one": return 1;
            case "two": return 2;
            case "three": return 3;
            case "four": return 4;
            case "five": return 5;
            case "six": return 6;
            case "seven": return 7;
            case "eight": return 8;
            case "nine": return 9;
        }

        return 0;
    }
}
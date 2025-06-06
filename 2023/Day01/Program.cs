/*
using System;
using System.IO;

namespace day_01;

internal class Program 
{
    private static int sum ;
    
    public static void Main(string[] args) {
        string path = @"G:\Projekty\C#\Advent of code\day-01\day-01\Values";
        string[] lines = File.ReadAllLines(path);

        foreach (var line in lines) 
            sum += ReturnNumber(line);

        Console.WriteLine(sum.ToString());
    }

    private static int ReturnNumber(string sentence) {
        int num1 = -1;
        int num2 = -1;
        char[] chars = sentence.ToCharArray();

        foreach (var c in chars) {
            if (!char.IsNumber(c)) continue;

            if (num1 == -1) 
                num1 = Int32.Parse(c.ToString()) * 10;
            else num2 = 
                Int32.Parse(c.ToString());
        }

        if (num2 == -1) num2 = num1 / 10;
        
        return num1 + num2;
    }
}
*/
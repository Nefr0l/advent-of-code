/*
using System;
using System.Collections.Generic;
using System.IO;

namespace day_02;

internal class Program
{
    private static int sum = 0;
    
    public static void Main(string[] args) 
    {
        String[] lines = File.ReadAllLines(@"G:\Projekty\C#\Advent of code\day-02\day-02\Values");

        for (int i = 0; i < lines.Length; i++) {
            if (GamePossible(lines[i])) {
                sum += (i + 1);
            }
        }

        Console.WriteLine(sum);
    }

    private static bool GamePossible(string line) {
        List<string> rounds = new List<string>();
        char[] chars = line.ToCharArray();

        List<int> red = new List<int>();
        List<int> green = new List<int>();
        List<int> blue = new List<int>();

        for (int i = 3; i < chars.Length; i++) {
            int x = 0;

            if (char.IsNumber(chars[i - 2])) 
                 x = Int32.Parse(chars[i-2].ToString());

            if (char.IsNumber(chars[i - 3])) {
                int y = Int32.Parse(chars[i - 3].ToString()) * 10;
                x += y;
            }
            
            if (chars[i] == 'r' && chars[i-1] != 'g') 
                red.Add(x);
            else if (chars[i] == 'g') 
                green.Add(x);
            else if (chars[i] == 'b') 
                blue.Add(x);
        }

        foreach (var x in red)
            if (x > 12)
                return false;

        foreach (var x in green) 
            if (x > 13) 
                return false;

        foreach (var x in blue) 
            if (x > 14)
                return false; 
                
        return true;
    }
}
*/

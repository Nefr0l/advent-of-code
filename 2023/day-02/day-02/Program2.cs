using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_02;

internal class Program
{
    private static int sum = 0;
    
    public static void Main(string[] args) 
    {
        String[] lines = File.ReadAllLines(@"G:\Projekty\C#\Advent of code\day-02\day-02\Values");

        for (int i = 0; i < lines.Length; i++) {
            GamePossible(lines[i]);
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

        sum += red.Max() * green.Max() * blue.Max();
        
        return true;

        
    }
}
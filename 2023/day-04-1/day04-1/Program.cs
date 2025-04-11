using System;
using System.Collections.Generic;
using System.IO;
namespace day04_1;

internal class Program
{
    private static readonly string[] lines = File.ReadAllLines(@"G:\Projekty\Advent of code\day-04-1\day04-1\Values");
    
    public static void Main()
    {
        Card value = GetValues(lines[0]);

        Console.WriteLine("Numery wygrywające:");
        foreach (var w in value.corrects)
            Console.Write(" | " + w);

        Console.WriteLine("");
        Console.WriteLine("Numery które były odgadywane:");
        foreach (var g in value.guesses)
            Console.Write(" | " + g);
    }

    private static Card GetValues(string line)
    {
        var corrects = new List<int>();
        var guesses = new List<int>();
        var chars = line.ToCharArray();
        bool crossedTheLine = false;
        
        // napisz kod który zwróci obiekt Card

        for (int i = 9; i < chars.Length - 1; i++)
        {
            // Przejście z uzupełniania zwycięskich numerów do tych które były odgadywane
            if (chars[i] == '|') crossedTheLine = true;
            
            // Sprawdzenie pierwszej liczby
            if (!char.IsNumber(chars[i])) continue;
            int number = int.Parse(chars[i].ToString());

            if (crossedTheLine) guesses.Add(number);
            else corrects.Add(number);

            // Sprawdzenie drugiej liczby
            if (!char.IsNumber(chars[i + 1])) continue;
            number = number * 10 + int.Parse(chars[i+1].ToString());
            
            if (crossedTheLine && guesses.Count > 0) guesses[guesses.Count - 1] = number;
            else if (corrects.Count > 0) corrects[corrects.Count - 1] = number;
            i++;
        }
        
        return new Card(guesses, corrects);
    }
}

/*
DZIAŁANIE KODU:

Dla każdej linijki:
- Zbierz wartośći numerów z danej linijki
- Oblicz wartość danej karty (1 pkt za pierwszy match, za każdy kolejny match pomnóż punkty razy dwa)
- Dodaj tę wartość do ogólnej sumy
*/

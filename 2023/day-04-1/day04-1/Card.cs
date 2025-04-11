using System.Collections.Generic;

namespace day04_1;

public class Card
{
    public List<int> guesses;
    public List<int> corrects;

    public Card(List<int> guesses, List<int> corrects)
    {
        this.guesses = guesses;
        this.corrects = corrects;
    }
}
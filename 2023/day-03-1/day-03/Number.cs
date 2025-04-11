using System.Collections.Generic;

namespace day_03;

public class Number
{
    public int value;
    public List<int> indexes;

    public Number(int value, List<int> indexes)
    {
        this.value = value;
        this.indexes = indexes;
    }
}
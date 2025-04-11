using System.Collections.Generic;

namespace day_03;

public class Number
{
    public int value;
    public List<int> indexes;
    public int line;

    public Number(int value, List<int> indexes, int line)
    {
        this.value = value;
        this.indexes = indexes;
        this.line = line;
    }
}
namespace advent._2023.Day03;

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

public class Number2
{
    public int value;
    public List<int> indexes;
    public int line;

    public Number2(int value, List<int> indexes, int line)
    {
        this.value = value;
        this.indexes = indexes;
        this.line = line;
    }
}
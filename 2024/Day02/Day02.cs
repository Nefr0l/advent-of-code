namespace advent._2024.Day02;

public class Day02
{
    public static void GetAnswer()
    {
        List<List<int>> Matrix = Helper.GetMatrix("../../../Day02/Day02.txt");

        int sum = 0;
        bool isTrue;
        
        for (var x = 0; x < Matrix.Count; x++)
        {
            isTrue = false;
            
            if (IsSafePartTwo(Matrix[x]))
            {
                isTrue = true;
            }
            else
            {
                for (int i = 0; i < Matrix[x].Count; i++)
                {
                    List<int> temp = new List<int>();

                    foreach (var n in Matrix[x])
                    {
                        temp.Add(n);
                    }
                    
                    temp.RemoveAt(i);

                    if (IsSafePartTwo(temp))
                    {
                        isTrue = true;
                    }
                }
            }

            if (isTrue)
            {
                sum++;
                Console.WriteLine($"True, sum: {sum}");
            }
        }
        
        Console.WriteLine(sum);
    }

    public static bool IsSafePartTwo(List<int> numbers)
    {
        bool isIncreasing = (numbers[0] - numbers[1] < 0);
        
        Console.WriteLine("");
        
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            int distance = numbers[i] - numbers[i + 1];
            bool isCorrect = (distance <= 3) && (distance >= -3) && (distance != 0) &&
                             ((isIncreasing && distance < 0) || (!isIncreasing && distance > 0));
            
            Console.WriteLine($"Distance i-j: {numbers[i]} - {numbers[i+1]} = {distance} correct: {isCorrect} (IsIncreasing is {isIncreasing})");

            if (!isCorrect)
            {
                return false;
            }
        }
        
        return true;
    }
}
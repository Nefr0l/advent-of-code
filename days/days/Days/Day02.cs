namespace days.Days;

public class Day02
{
    public static void GetAnswer()
    {
        List<List<int>> Matrix = Helper.GetMatrix("../../../Data/TestData.txt");

        int sum = 0;
        for (var x = 0; x < Matrix.Count; x++)
        {
            if (IsSafePartTwo(Matrix[x]))
            {
                sum++;
                Console.WriteLine($"True, sum: {sum}");
            }
        }
        
        Console.WriteLine(sum);
    }

    public static bool IsSafe(List<int> list)
    {
        int difference = 0;
        bool isIncreasing = (list[0] - list[1] < 0);
        
        Console.WriteLine($"Is increasing:  {isIncreasing}" );

        for (int i = 1; i < list.Count; i++)
        {
            difference = list[i] - list[i - 1];
            Console.WriteLine($"The difference between {list[i]} and {list[i-1]} is {difference}");

            if (difference > 3 || difference < -3 || difference == 0)
            {
                return false;
            }

            if (difference > 0 && isIncreasing == false)
            {
                return false;
            }
            
            if (difference < 0 && isIncreasing)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsSafePartTwo(List<int> numbers)
    {
        bool isIncreasing = (numbers[0] - numbers[1] < 0);
        bool isFlagged = false;
        
        Console.WriteLine("");
        
        for (int i = 0; i < numbers.Count - 2; i++)
        {
            int distance = numbers[i] - numbers[i + 1];
            bool isCorrect = (distance <= 3) && (distance >= -3) && (distance != 0) &&
                             ((isIncreasing && distance < 0) || (!isIncreasing && distance > 0));
            
            Console.WriteLine($"Distance i-j: {numbers[i]} - {numbers[i+1]} = {distance} correct: {isCorrect} (IsIncreasing is {isIncreasing})");

            if (!isCorrect)
            {
                if (isFlagged)
                {
                    return false;
                }
                
                if (i != numbers.Count - 1) // if it's last index it's useless to check
                {
                    Console.WriteLine("Flagging...");
                    isFlagged = true;
                    
                    // What to remove?
                    
                    int distance1 = numbers[i] - numbers[i + 2];
                    bool check1 = (distance1 <= 3) && (distance1 >= -3) && (distance1 != 0) &&
                                     ((isIncreasing && distance1 < 0) || (!isIncreasing && distance1 > 0));

                    if (check1)
                    {
                        numbers.RemoveAt(i+1);
                        isIncreasing = (numbers[0] - numbers[1] < 0);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            int distance2 = numbers[i + 1] - numbers[i + 2];
                            bool check2 = (distance2 <= 3) && (distance2 >= -3) && (distance2 != 0);

                            if (check2)
                            {
                                numbers.RemoveAt(i);
                                isIncreasing = (numbers[0] - numbers[1] < 0);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (i == 1)
                        {
                            int distance2 = numbers[i] - numbers[i + 1];
                            bool check2 = (distance2 <= 3) && (distance2 >= -3) && (distance2 != 0);

                            if (check2)
                            {
                                numbers.RemoveAt(i-1);
                                isIncreasing = (numbers[0] - numbers[1] < 0);
                            }
                            else
                            {
                                int distance3 = numbers[i+1] - numbers[i + 2];
                                bool check3 = (distance3 <= 3) && (distance3 >= -3) && (distance3 != 0);

                                if (check3)
                                {
                                    numbers.RemoveAt(i);
                                    isIncreasing = (numbers[0] - numbers[1] < 0);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            int distance3 = numbers[i + 1] - numbers[i + 2];
                            bool check3 = (distance3 <= 3) && (distance3 >= -3) && (distance3 != 0) &&
                                          ((isIncreasing && distance3 < 0) || (!isIncreasing && distance3 > 0));

                            if (check3)
                            {
                                int distance4 = numbers[i - 1] - numbers[i + 1];
                                bool check4 = (distance4 <= 3) && (distance4 >= -3) && (distance4 != 0) &&
                                              ((isIncreasing && distance4 < 0) || (!isIncreasing && distance4 > 0));

                                if (check4)
                                {
                                    numbers.RemoveAt(i);
                                    isIncreasing = (numbers[0] - numbers[1] < 0);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    
                    //

                    isIncreasing = (numbers[0] - numbers[1] < 0);
                    
                    
                    i--;
                }
            }
        }

        return true;
    }

}
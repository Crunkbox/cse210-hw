using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        
        do
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
            string userResponse = Console.ReadLine();

            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while(userNumber != 0);

        int sum = 0;
        
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");

        int smallMax = numbers[0];

        foreach (int number in numbers)
        {
            if (number > 0)
            {
                if (number < smallMax)
                {
                    smallMax = number;
                }
            }
        }
        Console.WriteLine($"The smallest positive number is: {smallMax}");

        numbers.Sort();

        Console.WriteLine("The numbers in ascending order:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
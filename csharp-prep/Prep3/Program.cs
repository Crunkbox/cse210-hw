using System;

class Program
{
    static void Main(string[] args)
    {
        string yesNo = "";
        do
        {
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(0,101);

            int guessNum = -217935498;

            int numOfGuesses = 0;

            

            do
            {
            Console.WriteLine("What is your guess? ");
            string guess = Console.ReadLine();
            guessNum = int.Parse(guess);

            if (guessNum < magicNum)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNum > magicNum)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it! :)");
            }
            numOfGuesses = numOfGuesses + 1;

            } while (guessNum != magicNum);

         Console.WriteLine($"It took you {numOfGuesses} times to guess correctly!");
         Console.WriteLine("Would you like to keep playing? (YES/NO, ALL CAPS) ");
         yesNo = Console.ReadLine();
        } while (yesNo == "YES");
    }
}
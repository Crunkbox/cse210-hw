using System;

class Program
{
    static void Main(string[] args)
    {
        
        Reference reference1 = new Reference(5, 0);

        Console.Clear();

        reference1.Passage1();
        
        while (true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to end program. ");
            string continueOrNot = Console.ReadLine()?.Trim().ToLower();
            
            if (continueOrNot == "quit")
            {
                Console.WriteLine("Ending program...");
                break;
            }
            else if (continueOrNot == "")
            {
                Console.Clear();
                reference1.DisplayHiddenVerse();

                if (reference1.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Hope you were able to memorize it!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Please just press Enter or type 'quit'.");
            }
        }
    }

}
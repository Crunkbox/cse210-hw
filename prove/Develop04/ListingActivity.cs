using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private int _numberOfResponses;

    public ListingActivity() : base(0)
    {

    }
    public void Listing()
    {
        Console.Clear();
        Console.WriteLine(_openingMessage[2]);
        Console.WriteLine(_descriptions[2]);

        Console.WriteLine("Enter the duration, in seconds, for however long you would like to list entries (hit Enter for 30 seconds): ");
        if (!int.TryParse(Console.ReadLine(), out int durationInSeconds))
        {
            Console.WriteLine("Doing reflection for 30 seconds.");
            durationInSeconds = 30;
        }

        string prompt = PromptSelector(_prompts);

        Console.Clear();
        Console.WriteLine("Get ready...");
        Animation(3);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("\n --- " + prompt + " ---");
        for (int i = 5; i >= 1; i--)
        {
            Console.Write($"You may begin in: {i} \r");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
        _numberOfResponses = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrEmpty(response))
            {
                _numberOfResponses++;
            }
            Console.WriteLine();
        }

        Console.WriteLine($"You listed {_numberOfResponses}");

        Console.WriteLine("\n" + _closingMessage);
        Animation(3);

        Console.WriteLine($"\nYou have completed another {durationInSeconds} of the Breathing Activity.");
        Animation(3); 
    }

}
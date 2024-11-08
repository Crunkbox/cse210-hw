using System;

public class ReflectionActivity : Activity
{
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base(0)
    {

    }
    public void Reflecting()
    {
        Console.Clear();
        Console.WriteLine(_openingMessage[1]);
        Console.WriteLine(_descriptions[1]);

        Console.WriteLine("Enter the duration, in seconds, for however long you would like to reflect (hit Enter for 30 seconds): ");
        if (!int.TryParse(Console.ReadLine(), out int durationInSeconds))
        {
            Console.WriteLine("Doing reflection for 30 seconds.");
            durationInSeconds = 30;
        }

        Console.Clear();
        Console.WriteLine("Get Ready...");
        Animation(3);

        string initialThought = PromptSelector(_thoughts);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("\n--- " + initialThought + " ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        for (int i = 5; i >= 1; i--)
            {
                Console.Write($"You may begin in: {i} \r");
                Thread.Sleep(1000);
            }

        Console.Clear();

        List<string> unusedQuestions = new List<string>(_questions);

        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while(DateTime.Now < endTime)
        {
            if (unusedQuestions.Count == 0)
            {
                unusedQuestions = new List<string>(_questions);
            }

            string question = PromptSelector(unusedQuestions);
            Console.WriteLine(question);

            unusedQuestions.Remove(question);

            Animation(15);

            Console.WriteLine();
        }

        Console.WriteLine("\n" + _closingMessage);
        Animation(3);
        
        Console.WriteLine($"\nYou have completed another {durationInSeconds} of the Breathing Activity.");
        Animation(3); 
    }
}
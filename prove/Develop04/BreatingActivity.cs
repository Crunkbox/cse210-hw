using System;

public class BreathingActivity : Activity
{
    private string _breatheIn = "Breathe in...";
    private string _breatheOut = "Breathe out...";

    public BreathingActivity() : base(0)
    {
        
    }
    public void Breathing()
    {
        Console.Clear();
        Console.WriteLine(_openingMessage[0]);
        Console.WriteLine(_descriptions[0]);

        Console.WriteLine("Enter the duration, in seconds, for however long you would like to breathe (hit Enter for 30 seconds): ");
        if (!int.TryParse(Console.ReadLine(), out int durationInSeconds))
        {
            Console.WriteLine("Okay, going for 30 seconds.");
            durationInSeconds = 30;
        }
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        Animation(3);

        DateTime endtime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endtime)
        {
            for (int i = 4; i >= 1; i--)
            {
                Console.Write($"{_breatheIn} {i} \r");
                Thread.Sleep(1000);
            }

            for (int i = 4; i >= 1; i--)
            {
                Console.Write($"{_breatheOut} {i} \r");
                Thread.Sleep(1000);
            }
        }

        Console.WriteLine("\n" + _closingMessage);
        Animation(3);

        Console.WriteLine($"\nYou have completed another {durationInSeconds} of the Breathing Activity.");
        Animation(3); 
    }
}
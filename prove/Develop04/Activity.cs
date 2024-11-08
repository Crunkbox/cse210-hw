using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class Activity
{
    protected int _time;
    private int _pauseTime;
    protected List<string> _thoughts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you realized that your burdens became light.",
        "Think of a time when you succeeded despite the roadblocks that were in your way."
    };
    protected List<string> _descriptions = new List<string>()
    {
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    };
    protected List<string> _openingMessage = new List<string>()
    {
        "Welcome! We will be doing a breathing exercise for the duration requested. Relax and follow the on screen prompts as they appear.",
        "Welcome! We will be doing a reflection exercise for the duration requested. Relax and contemplate on the prompts as they appear.",
        "Welcome! We will be doing a listing exercise for the duration requested. Get comfortable and respond to as many prompts within the time limit."
    };
    protected string _closingMessage = "Exercise finished! Hope you enjoyed your time here. See you another time!";
    protected Random _random = new Random();
    private CancellationTokenSource _cancellationTokenSource;

    public Activity(int time)
    {
        _time = time;
    }
    public void Animation(int durationInSeconds)
    {
        char[] spinner = {'\\', '|', '/', '-'};
        int iterations = durationInSeconds * 10;

        for (int i = 0; i < iterations; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    public void Pause()
    {
        _pauseTime = 5;
        Animation(_pauseTime);
    }
    public void Time(int timeInSeconds)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = _cancellationTokenSource.Token;

        Task.Run(async () =>
        {
            await Task.Delay(timeInSeconds * 1000, token);
            if (!token.IsCancellationRequested)
            {
                Console.WriteLine("Activity has ended. See you next time!");
                _cancellationTokenSource.Cancel();
            }
        }, token);
    }
    public string PromptSelector(List<string> strings)
    {
        if (strings == null || strings.Count == 0)
        {
            throw new ArgumentException("The list cannot be null or empty.");
        }

        int index = _random.Next(strings.Count);
        return strings[index];
    }
}
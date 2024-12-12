using System;

class Program
{
    static void Main(string[] args)
    {
        Activity running = new RunningActivity("01 Jan 2025", 25, 5.0);
        Activity cycling = new CyclingActivity("02 Jan 2025", 30, 20.0);
        Activity swimming = new SwimmingActivity("03 Jan 2025", 15, 50);

        List<Activity> activities = new List<Activity> {running, cycling, swimming};

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
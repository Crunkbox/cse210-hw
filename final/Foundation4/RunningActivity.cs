using System;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, int minutes, double distance) : base (date, minutes)
    {
        _distance = distance;
    }
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        return 60 / GetPace();
    }
    public override double GetPace()
    {
        return _minutes / _distance;
    }
}
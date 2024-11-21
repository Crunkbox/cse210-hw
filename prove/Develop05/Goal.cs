public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    protected int _value;
    private static List<string> _goals = new List<string>();
    private bool _complete;

    public Goal()
    {

    }
    public static List<string> Goals => _goals;
    protected bool IsComplete => _complete;
    protected string GoalName => _goalName;
    protected string GoalDescription => _goalDescription;
    protected void SetComplete()
    {
        _complete = true;
    }
    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }
    public void SetGoalDescription(string goalDescription)
    {
        _goalDescription = goalDescription;
    }
    public void SetValue(int value)
    {
        _value = value;
    }
    public abstract int RecordEvent();
    
    public abstract string ToDisplayString();
}
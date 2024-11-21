public class EternalGoal : Goal
{
    public EternalGoal() : base ()
    {

    }
    public void CreateEternalGoal()
    {
        Console.WriteLine("Enter the name of your goal: ");
        string goalName = Console.ReadLine();

        Console.WriteLine("Enter a short description of your goal: ");
        string goalDescription = Console.ReadLine();

        Console.WriteLine("Enter a whole number for the value of completing this goal: ");
        int goalValue;
        while (!int.TryParse(Console.ReadLine(), out goalValue))
        {
            Console.WriteLine("Invalid Input. Please enter a whole number: ");
        }

        SetGoalName(goalName);
        SetGoalDescription(goalDescription);
        SetValue(goalValue);

        string goalEntry = $"EternalGoal|{goalName}|({goalDescription})|{goalValue}";
        Goals.Add(goalEntry);
    }
    public override int RecordEvent()
    {
        Console.WriteLine($"You completed \"{GoalName}\"! +{_value} points!");
        return _value;
    }
    public override string ToDisplayString()
    {
        return $"[ ] \"{GoalName} \" ({GoalDescription})";
    }
    public void RestoreFromSerializedData(string serializedData)
    {
        string[] parts = serializedData.Split("|");
        SetGoalName(parts[1]);
        SetGoalDescription(parts[2].Trim('(', ')'));
        SetValue(int.Parse(parts[3]));
    }

}
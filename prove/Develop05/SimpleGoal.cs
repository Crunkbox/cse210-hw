public class SimpleGoal : Goal
{
    private bool _completionStatus = false;

    public SimpleGoal() : base() { }

    public void CreateSimpleGoal()
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

        UpdateGoalEntry();
    }

    public override int RecordEvent()
    {
        if (!_completionStatus)
        {
            _completionStatus = true;
            SetComplete();
            Console.WriteLine($"You completed \"{GoalName}\"! +{_value} points!");

            UpdateGoalEntry();
            return _value;
        }
        else
        {
            Console.WriteLine($"\"{GoalName}\" has already been completed. No points awarded.");
            return 0;
        }
    }

    public override string ToDisplayString()
    {
        string status = _completionStatus ? "[x]" : "[ ]";
        return $"{status} \"{GoalName}\" ({GoalDescription})";
    }

    public void RestoreCompletionStatus(bool completionStatus)
    {
        _completionStatus = completionStatus;
        if (!completionStatus)
        {
            SetComplete();
        }
    }

    private void UpdateGoalEntry()
    {
        string goalEntry = $"SimpleGoal|{GoalName}|{GoalDescription}|{_value}|{_completionStatus}";
        int index = Goals.FindIndex(g => g.StartsWith($"SimpleGoal|{GoalName}|"));
        if (index >= 0)
        {
            Goals[index] = goalEntry;
        }
        else
        {
            Goals.Add(goalEntry);
        }
    }
    public void RestoreFromSerializedData(string serializedData)
    {
        string[] parts = serializedData.Split("|");
        SetGoalName(parts[1]);
        SetGoalDescription(parts[2].Trim('(', ')'));
        SetValue(int.Parse(parts[3]));
        RestoreCompletionStatus(bool.Parse(parts[4]));
    }

}

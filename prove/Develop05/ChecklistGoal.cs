public class ChecklistGoal : Goal
{
    private int _amountOfTimes;
    private int _bonusPoints;
    private int _currentCompletions;

    
    public ChecklistGoal() : base ()
    {

    }
    public int BonusPoints
    {
        get => _bonusPoints;
        set => _bonusPoints = value;
    }
    public int AmountOfTimes
    {
        get => _amountOfTimes;
        set => _amountOfTimes = value;
    }
    public int CurrentCompletions
    {
        get => _currentCompletions;
        private set => _currentCompletions = value;
    }
    public void CreateChecklistGoal()
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
        
        Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
        while (!int.TryParse(Console.ReadLine(), out _amountOfTimes))
        {
            Console.WriteLine("Invalid Input. Please enter a whole number: ");
        }

        Console.WriteLine("What is the bonus for accomplishing it that many times? ");
        while (!int.TryParse(Console.ReadLine(), out _bonusPoints))
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
        if (_currentCompletions < _amountOfTimes)
        {
            _currentCompletions++;
            UpdateGoalEntry();

            if (_currentCompletions == _amountOfTimes)
            {
                SetComplete();
                return _value + _bonusPoints;
            }
            return _value;
        }
        else
        {
            Console.WriteLine($"\"{GoalName}\" is already fully completed. No points awarded.");
            return 0;
        }
    }
    public override string ToDisplayString()
    {
        string status = _currentCompletions >= _amountOfTimes ? "[x]" : "[ ]";
        return $"{status} \"{GoalName}\" ({GoalDescription}) -- Currently completed: {_currentCompletions}/{_amountOfTimes}";
    }
    public void RestoreFromSerializedData(string serializedData)
    {
        string[] parts = serializedData.Split("|");
        SetGoalName(parts[1]);
        SetGoalDescription(parts[2].Trim('(',')'));
        SetValue(int.Parse(parts[3]));
        _bonusPoints = int.Parse(parts[4]);
        _amountOfTimes = int.Parse(parts[5]);
        _currentCompletions = int.Parse(parts[6]);
    }
    private void UpdateGoalEntry()
    {
        string goalEntry = $"ChecklistGoal|{GoalName}|{GoalDescription}|{_value}|{_bonusPoints}|{_amountOfTimes}|{_currentCompletions}";
        int index = Goals.FindIndex(g => g.StartsWith($"ChecklistGoal|{GoalName}|"));
        
        if (index >= 0)
        {
            Goals[index] = goalEntry;
        }
        else
        {
            Goals.Add(goalEntry);
        }
    }
}
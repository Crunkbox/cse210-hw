public class SaveLoadGoal
{
    public SaveLoadGoal()
    {

    }

    public void Save(List<string> goalEntries, int points)
    {
        try
        {
            if (goalEntries.Count > 0 && goalEntries[0].StartsWith("Points|"))
            {
                goalEntries[0] = $"Points|{points}";
            }
            else
            {
                goalEntries.Insert(0, $"Points|{points}");
            }
    
            Console.WriteLine("Enter the full path (including the file name) to save your goals:");
            string filePath = Console.ReadLine();
    
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Invalid file path. Please try again.");
                return;
            }
    
            File.WriteAllLines(filePath, goalEntries);
    
            Console.WriteLine($"Goals have been successfully saved to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }


    public List<string> Load()
    {
        List<string> goals = new List<string>();
        try
        {
            Console.WriteLine("What file would like to retrieve goals from? ");
            string filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                goals = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
        return goals;
    }
}

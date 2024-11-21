using System;

class Program
{
    static void Main(string[] args)
    {
        int points = 0;
        SimpleGoal simpleGoal = new SimpleGoal();
        EternalGoal eternalGoal = new EternalGoal();
        ChecklistGoal checklistGoal = new ChecklistGoal();
        SaveLoadGoal saveLoadGoal = new SaveLoadGoal();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine($"You have {points} points.");
            Console.WriteLine("Menu Options: \n1. Create New Goal \n2. List Goals \n3. Save Goals \n4. Load Goals \n5. Record Event \n6. Quit");

            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                Console.WriteLine("The types of Goals are: \n1. Simple Goal \n2. Eternal Goal \n3. Checklist Goal");

                Console.WriteLine("What type of goal would you like to create? ");
                string subChoice = Console.ReadLine();

                switch (subChoice)
                {
                    case "1":
                    simpleGoal.CreateSimpleGoal();
                    break;

                    case "2":
                    eternalGoal.CreateEternalGoal();
                    break;

                    case "3":
                    checklistGoal.CreateChecklistGoal();
                    break;

                    default:
                    Console.WriteLine("Invalid selection. Please choose a valid option.");
                    break;
                }
                break;

                case "2":
                Console.WriteLine("The goals are: ");
                if (Goal.Goals.Count > 0)
                {
                    foreach (var goalString in Goal.Goals)
                    {
                        string[] parts = goalString.Split("|");

                        if (parts[0] == "Points")
                        {
                            continue;
                        }

                        Goal goal;

                        if (parts[0] == "SimpleGoal")
                        {
                            goal = new SimpleGoal();
                            ((SimpleGoal)goal).RestoreFromSerializedData(goalString);
                        }
                        else if (parts[0] == "ChecklistGoal")
                        {
                            goal = new ChecklistGoal();
                            ((ChecklistGoal)goal).RestoreFromSerializedData(goalString);
                        }
                        else
                        {
                            goal = new EternalGoal();
                            ((EternalGoal)goal).RestoreFromSerializedData(goalString);
                        }

                        Console.WriteLine(goal.ToDisplayString());
                    }
                }
                else
                {
                    Console.WriteLine("You have no goals currently.");
                }
                break;


                case "3":
                Console.WriteLine("Initializing saving...");
                saveLoadGoal.Save(Goal.Goals, points);
                break;

                case "4":
                Console.WriteLine("Initializing loading...");
                List<string> goals = saveLoadGoal.Load();
                Goal.Goals.Clear();
                Goal.Goals.AddRange(goals);

                if (Goal.Goals.Count > 0)
                {
                    string[] parts = Goal.Goals[0].Split("|");
                    points = int.Parse(parts[parts.Length - 1]);
                }
                break;

                case "5":
                    Console.WriteLine("The goals are: ");
                    if (Goal.Goals.Count > 0)
                    {
                        int displayIndex = 1;
                        List<int> actualIndices = new List<int>();

                        for (int i = 0; i < Goal.Goals.Count; i++)
                        {
                            string[] parts = Goal.Goals[i].Split("|");

                            if (parts[0] == "Points")
                            {
                                continue;
                            }

                            string goalType = parts[0];
                            string goalName = parts[1];
                            Console.WriteLine($"{displayIndex}. {goalType} - \"{goalName}\"");
                            actualIndices.Add(i);
                            displayIndex++;
                        }

                        Console.WriteLine("Select the goal number you completed: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedDisplayIndex) 
                            && selectedDisplayIndex > 0 
                            && selectedDisplayIndex <= actualIndices.Count)
                        {
                            int actualIndex = actualIndices[selectedDisplayIndex - 1];
                            string goalString = Goal.Goals[actualIndex];
                            string[] parts = goalString.Split("|");
                            Goal goal;

                            if (parts[0] == "SimpleGoal")
                            {
                                goal = new SimpleGoal();
                                ((SimpleGoal)goal).RestoreFromSerializedData(goalString);
                            }
                            else if (parts[0] == "ChecklistGoal")
                            {
                                goal = new ChecklistGoal();
                                ((ChecklistGoal)goal).RestoreFromSerializedData(goalString);
                            }
                            else
                            {
                                goal = new EternalGoal();
                                ((EternalGoal)goal).RestoreFromSerializedData(goalString);
                            }

                            int pointsEarned = goal.RecordEvent();
                            if (pointsEarned > 0)
                            {
                                points += pointsEarned;
                                Console.WriteLine($"Points earned: {pointsEarned}.");
                            }
                            else
                            {
                                Console.WriteLine("This goal has already been completed, or no points are awarded.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Returning to the menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no goals to record events for.");
                    }
                    break;


                case "6":
                Console.WriteLine("Exiting the program. Until next time!");
                running = false;
                break;

                default:
                Console.WriteLine("Invalid selection. Please choose a valid option.");
                break;
            }
            if (running)
            {
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
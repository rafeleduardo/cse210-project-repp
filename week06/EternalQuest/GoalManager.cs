public class GoalManager
{
    private List<Goal> _goals = [];
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();

                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine());

                    if (goalType == "1")
                    {
                        CreateGoal(new SimpleGoal(name, description, points));
                    }
                    else if (goalType == "2")
                    {
                        CreateGoal(new EternalGoal(name, description, points));
                    }
                    else if (goalType == "3")
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        int bonus = int.Parse(Console.ReadLine());
                        CreateGoal(new ChecklistGoal(name, description, points, target, bonus));
                    }
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    SaveGoals(saveFile);
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    LoadGoals(loadFile);
                    break;
                case "5":
                    ListGoalNames();
                    Console.Write("Which goal did you accomplish? ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    RecordEvent(goalIndex);
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals names are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals details are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    private void RecordEvent(int goalIndex)
    {
        int pointsEarned = _goals[goalIndex].RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points!");
    }

    private void SaveGoals(string filename)
    {
        using StreamWriter outputFile = new StreamWriter(filename);
        outputFile.WriteLine(_score);
        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }
    }

    private void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string[] goalData = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                if (bool.Parse(goalData[3]))
                {
                    goal.RecordEvent(); // Mark as complete
                }
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[4]), int.Parse(goalData[3]));
                for(int j = 0; j < int.Parse(goalData[5]); j++)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
        }
    }
}
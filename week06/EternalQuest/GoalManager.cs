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
        int level = 1 + (_score / 1000);
        Console.WriteLine($"You are Level {level}");
        Console.WriteLine($"You have {_score} points.");
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
        int oldLevel = 1 + (_score / 1000);
        int pointsEarned = _goals[goalIndex].RecordEvent();
        _score += pointsEarned;
        int newLevel = 1 + (_score / 1000);

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points!");

        if (newLevel > oldLevel)
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine($"Congratulations! You've reached Level {newLevel}!");
            Console.WriteLine("*****************************************\n");
        }
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
        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();
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
                        goal.RecordEvent();
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
                    int amountCompleted = int.Parse(goalData[5]);
                    for (int j = 0; j < amountCompleted; j++)
                    {
                        goal.RecordEvent();
                    }
                    
                    _score -= (amountCompleted * int.Parse(goalData[2]));
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filename}' was not found.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
            Console.WriteLine("The file may be corrupt or in an incorrect format.");
            _goals.Clear();
            _score = 0;
        }
    }
}
using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {

        List<Activity> activities = new List<Activity>();
        
        activities.Add(new Running(new DateOnly(2025, 08, 11), 30, 3.0));
        activities.Add(new StationaryBicycles(new DateOnly(2025, 08, 12), 45, 15.0));
        activities.Add(new Swimming(new DateOnly(2025, 08, 13), 60, 40));

        Console.WriteLine("***** Exercise Log *****\n");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        Console.WriteLine("***** End of Log *****");
    }
}

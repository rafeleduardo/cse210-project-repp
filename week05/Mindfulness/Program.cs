class Program
{
    /// <summary>
    /// This program provides three mindfulness activities: Breathing, Reflection, and Listing.
    /// 
    /// Exceeding Requirements Feature:
    /// To enhance the user experience, the Reflection and Listing activities ensure
    /// that no random prompt or question is repeated until all available options
    /// have been displayed at least once in the current session. This prevents
    /// immediate repetition and provides a greater variety of prompts.
    /// </summary>
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("\nCome back soon!\n");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}

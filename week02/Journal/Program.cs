using Journal;

class Program
{
    static void Main(string[] args)
    {
        PersonalJournal myJournal = new PersonalJournal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        Console.WriteLine("Welcome to the PersonalJournal Program!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(randomPrompt);
                    Console.Write("> ");
                    string answer = Console.ReadLine();
                    JournalEntry newEntry = new JournalEntry();
                    newEntry._prompt = randomPrompt;
                    newEntry._answer = answer;
                    
                    myJournal.AddJournalEntry(newEntry);
                    Console.WriteLine("Entry added!");
                    break;
                case "2":
                    // Display the journal
                    myJournal.DisplayAllEntries();
                    break;
                case "3":
                    // Load the journal
                    Console.Write("What is the filename to load? (e.g., my_journal.txt) ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        myJournal.LoadTheJournal(loadFile);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"Error: The file '{loadFile}' was not found.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
                    }
                    break;
                case "4":
                    // Save the journal
                    Console.Write("What is the filename to save to? (e.g., my_journal.txt) ");
                    string saveFile = Console.ReadLine();
                     try
                    {
                        myJournal.SaveTheJournal(saveFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
                    }
                    break;
                case "5":
                    // Quit the program
                    running = false;
                    Console.WriteLine("Goodbye! Come back soon.");
                    break;
                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
}
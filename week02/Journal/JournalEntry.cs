namespace Journal;

public class JournalEntry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Answer { get; }

    public JournalEntry(String prompt, String answer)
    {
        Prompt = prompt;
        Answer = answer;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }
    
    public void ShowEntry()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
        Console.WriteLine($"{Answer}");
        Console.WriteLine();
    }
}
namespace Journal;

public class JournalEntry
{
    public string _date = DateTime.Now.ToString("yyyy-MM-dd");
    public string _prompt;
    public string _answer;
    
    public void ShowEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_answer}");
        Console.WriteLine();
    }
}
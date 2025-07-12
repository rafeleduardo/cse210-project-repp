using System.Text.Json;

namespace Journal;

public class PersonalJournal
{
    public List<JournalEntry> _journalEntries = new();
    
    public void AddJournalEntry(JournalEntry entry) 
    {
        _journalEntries.Add(entry);
    }
    
    public void DisplayAllEntries()
    {
        if (_journalEntries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Try writing something first!");
            return;
        }

        Console.WriteLine("\n--- Your personal journal Entries ---");
        foreach (var entry in _journalEntries)
        {
            entry.ShowEntry();
        }
        Console.WriteLine("--- End of your personal journal ---\n");
    }

    public void SaveTheJournal(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_journalEntries, options);
        File.WriteAllText(filename, jsonString);
        Console.WriteLine($"Your personal journal was successfully saved to {filename}");
    }

    public void LoadTheJournal(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        _journalEntries = JsonSerializer.Deserialize<List<JournalEntry>>(jsonString);
        Console.WriteLine($"Your personal journal was successfully loaded from {filename}");
    }
}
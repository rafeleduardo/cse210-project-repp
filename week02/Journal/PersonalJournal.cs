namespace Journal;

public class PersonalJournal
{
    public List<JournalEntry> _journalEntries = new List<JournalEntry>();
    
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
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in _journalEntries)
            {
                var e = $"{entry._date}|{entry._prompt}|{entry._answer}";
                outputFile.WriteLine(e);
            }
        }
        Console.WriteLine($"Your personal journal was successfully saved to {filename}");
    }

    public void LoadTheJournal(string filename)
    {
        _journalEntries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3)
            {
                JournalEntry entry = new JournalEntry();
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._answer = parts[2];
                
                AddJournalEntry(entry);
            }
        }
        Console.WriteLine($"Your personal journal was successfully loaded from {filename}");
    }
}
using System.Text.Json;

/*
 * =====================================================================================
 *   Scripture Memorizer Program - Design and Implementation Notes
 * =====================================================================================
 *
 * This program helps users memorize scriptures through a series of random prompts. The
 * idea is to hide several words and try to do it until all the words are hidden.
 * 
 * The following notes describe new feature to make it more flexible.
 * 
 * === 1. Process Enhancements ===
 * a. Scripture Library: The program loads scriptures from a JSON file containing
 *    passages from various sources (Book of Mormon, Pearl of Great Price,
 *    Doctrine and Covenants, Old and New Testament) and selects one at random.
 *    This creates a more varied and unpredictable memorization experience. If the file
 *    does not exist, it uses a default scripture. 
 */

class Program
{
    static Scripture LoadScriptureFromJson()
    {
        try
        {
            string jsonString = File.ReadAllText("scriptures.json");
            List<ScriptureData> scriptureList = JsonSerializer.Deserialize<List<ScriptureData>>(jsonString);
            
            Random random = new Random();
            int randomIndex = random.Next(0, scriptureList.Count);
            
            ScriptureData selectedScripture = scriptureList[randomIndex];

            Reference reference = new Reference(
                selectedScripture.book,
                selectedScripture.chapter,
                selectedScripture.verseStart,
                selectedScripture.verseEnd);

            return new Scripture(reference, selectedScripture.text);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scripture from JSON: {ex.Message}");
            Reference defaultReference = new Reference("2 Nephi", 2, 25);
            string defaultText = "Adam fell that men might be; and men are, that they might have joy.";
            return new Scripture(defaultReference, defaultText);
        }
    }

    static void Main(string[] args)
    {
        Scripture scripture = LoadScriptureFromJson();
        string input = "";

        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (!scripture.IsCompletelyHidden()) return;
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("All words have been hidden. Congratulations!");
    }
}
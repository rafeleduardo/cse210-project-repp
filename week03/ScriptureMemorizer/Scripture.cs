public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        if (visibleWords.Count == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(0, visibleWords.Count);
            visibleWords[randomIndex].HideWord();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();

        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{referenceText}\n{scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

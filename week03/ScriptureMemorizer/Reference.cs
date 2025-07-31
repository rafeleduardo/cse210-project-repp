using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _initialVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _initialVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int initialVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _initialVerse = initialVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_initialVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_initialVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_initialVerse}-{_endVerse}";
        }
    }
}

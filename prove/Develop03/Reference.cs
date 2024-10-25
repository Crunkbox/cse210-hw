using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    // private int _endVerse;
    private string _hiddenVerse;
    private int _verseIndex;

    private Scripture scripture1;

    public Reference(int startVerse, int verseIndex)
    {
        _startVerse = startVerse;
        _verseIndex = verseIndex;
        _book = "Proverbs";
        _chapter = 3;
        scripture1 = new Scripture();
    }

    public void Passage1()
    {
        string originalVerse = scripture1.GetRendered(_verseIndex);
        Console.WriteLine($"{_book} {_chapter}: {_startVerse} {originalVerse}");
    }

    public void DisplayHiddenVerse()
    {
        scripture1.HideWords(_verseIndex);

        _hiddenVerse = scripture1.GetRendered(_verseIndex);

        Console.WriteLine($"{_book} {_chapter}: {_startVerse} {_hiddenVerse}");
    }

    public bool AllWordsHidden()
    {
        return scripture1.AreAllWordsHidden(_verseIndex);
    }
}
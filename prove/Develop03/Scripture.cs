using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private List<string> verses = new List<string>()
    {
        "Trust in the Lord with all thine heart; and lean not unto thine own understanding.",
        "In all thy ways acknowledge him, and he shall direct thy paths."
    };

    private Dictionary<int, List<Word>> hiddenWords;
    public Scripture()
    {
        hiddenWords = new Dictionary<int, List<Word>>();

        for (int i = 0; i < verses.Count; i++)
        {
            var words = verses[i].Split(" ").Select(word => new Word(word)).ToList();

            hiddenWords[i] = words;
        }        
    }
    public void HideWords(int verseIndex)
    {
        if (verseIndex < 0 || verseIndex >= verses.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid verse index");
        }

        var words = hiddenWords[verseIndex];

        List<int> indices = Enumerable.Range(0, words.Count).Where(i => !words[i].IsHidden()).ToList();

        if (indices.Count == 0)
        {
            throw new InvalidOperationException("All words are hidden.");
        }

        HideAvailableWords(indices, words);
    }
    public string GetRendered(int verseIndex)
    {
        if (verseIndex <0 || verseIndex >= verses.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid verse index");
        }

        var words = hiddenWords[verseIndex];
        return string.Join(" ", words.Select(word => word.Show()));
    }
    private void HideAvailableWords(List<int> indices, List<Word> words)
    {
        if (indices.Count > 0)
        {
            Random random = new Random();

            int wordsThatAreLeft = Math.Min(3, indices.Count);
            List<int> selectedIndices = indices.OrderBy(x => random.Next()).Take(wordsThatAreLeft).ToList();
            foreach (int index in selectedIndices)
            {
                words[index].Hide();
            }
        }
    }
    public bool AreAllWordsHidden(int verseIndex)
    {
        if (verseIndex < 0 || verseIndex >= verses.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid verse index");
        }

        var words = hiddenWords[verseIndex];
        return words.All(word => word.IsHidden());
    }
}
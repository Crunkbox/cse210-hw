using System;
using System.Collections.Generic;
public class Entry
{
    public string _userInput;
    public string _date = DateTime.Now.ToString("yyyy-MM-dd");
    public List<List<string>> _entries = new List<List<string>>();

    
    
    public string Write(string prompt)
    {
        Console.WriteLine(prompt);
        string userinput = Console.ReadLine();

        return userinput;
    }

    public void AddEntry(string prompt, string input, string date)
    {
        List<string> entry = new List<string> { prompt, input, date };
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (var entry in _entries)
        {
            string entryDisplay = string.Join(" | ", entry);
            Console.WriteLine(entryDisplay);
        }
    }

    public string GeneratePrompt()
    {
        List<string> prompt = new List<string>
        {
            "What good have you done today?",
            "What could you have done better today?",
            "What was the best thing you ate today?",
            "There is no war in Ba Sing Sei.",
            "How did you recognize the Lord's hand in your life today?",
            "What are your plans for tomorrow?"
        };

        Random question = new Random();

        int index = question.Next(prompt.Count);

        return prompt[index];
    }
}
using System;
using System.Collections.Generic;

class Program
{
    private Entry _entry1 = new Entry();
    private Journal _journal1 = new Journal();

    public void Menu()
    {
         bool running = true;
        
        while (running)
        {
            Console.WriteLine("Please select one of the following options.");
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Display the journal.");
            Console.WriteLine("3. Save the journal to a file.");
            Console.WriteLine("4. Load the journal from a file.");
            Console.WriteLine("5. Quit ");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Write();
                    break;
                case "2":
                    Display();
                    break;
                case "3":
                    Save();
                    break;
                case "4":
                    Load();
                    break;
                case "5":
                    running = false;
                    Quit();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select an option from 1-5.");
                    break;
            }
        }
    }
    private void Write()
    {
        string genPrompt = _entry1.GeneratePrompt();
        string userInput = _entry1.Write(genPrompt);
        string date = _entry1._date;

        _entry1.AddEntry(genPrompt, userInput, date);
        Console.WriteLine("Your secrets are secured.");
    }

    private void Display()
    {
        Console.WriteLine("\nEmptying contents of this session:\n");

        if (_entry1._entries.Count == 0)
        {
            Console.WriteLine("I ain't got nothin' to give ya!");
        }
        else
        {
            _entry1.Display();
        }
    }
    private void Save()
    {
        Console.WriteLine("Enter the name of the text file you would like to save to: ");
        string filename = Console.ReadLine();

        _journal1.Save(filename, _entry1._entries);
    }
    private void Load()
    {
        Console.WriteLine("Enter the name of the text file you will be pulling entries from: ");
        string filename = Console.ReadLine();

        _entry1._entries = _journal1.Load(filename);
    }
    private void Quit()
    {
        Console.WriteLine("Bye-bye!");
    }
    static void Main(string[] args)
    {
       Program program = new Program();
       program.Menu();
    }
}
using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    public string _filename;

    public void Save(string filename, List<List<string>> entries, bool append = true)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, append))
        {
            Console.WriteLine("Saving to file...");
            foreach (var entry in entries)
            {
                string line = string.Join("|", entry);
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine(Path.GetFullPath(filename) + " has been updated with new entries.");
    }

    public List<List<string>> Load(string filename)
    {
        List<List<string>> entries = new List<List<string>>();

        if (File.Exists(filename))
        {
            using (StreamReader inputFile = new StreamReader(filename))
            {
                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    List<string> entry = new List<string>(line.Split("|"));
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Pulled entries from " + filename);
        }
        else
        {
            Console.WriteLine(filename + " does not exist.");
        }

        return entries;
    }
}
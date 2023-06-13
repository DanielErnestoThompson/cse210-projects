using System;
using System.IO;
using System.Collections.Generic;

// Entry Class
public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

// Journal Class
public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<Entry>();
        prompts = new List<string>(){
            "What did I learn from those I interacted with today?",
            "What am I grateful for today?",
            "When and where did I see the Lord in my life today?",
            "What did I accomplish today?",
            "What do I need to work on for tomorrow?"
        };
    }

    public void AddEntry()
    {
        var prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine(prompt);

        var response = Console.ReadLine();
        var date = DateTime.Now.ToString();

        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt} - {entry.Response}");
        }
    }

    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split("~|~");
                entries.Add(new Entry(parts[1], parts[2], parts[0]));
            }
        }
    }
}

// Program Class
public class Program
{
    public static void Main(string[] args)
    {
        var journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Add entry\n2. Display entries\n3. Save to file\n4. Load from file\n5. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.WriteLine("Enter filename to save:");
                    var saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.WriteLine("Enter filename to load:");
                    var loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    return;
            }
        }
    }
}

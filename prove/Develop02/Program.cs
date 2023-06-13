using System;
using System.IO;
using System.Collections.Generic;

// Entry Class
public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }
    public string Category { get; }

    public Entry(string prompt, string response, string date, string category)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Category = category;
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

        // Predefined list of categories
        List<string> categories = new List<string>()
        {
            "Work",
            "Family",
            "Leisure",
            "Health",
            "Education"
        };

        int categoryIndex = -1;
        while (categoryIndex < 0 || categoryIndex >= categories.Count)
        {
            Console.WriteLine("Please select a category for this entry:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i+1}. {categories[i]}");
            }

            if (!int.TryParse(Console.ReadLine(), out categoryIndex) || categoryIndex < 1 || categoryIndex > categories.Count)
            {
                Console.WriteLine("Invalid input. Please enter a number corresponding to one of the categories.");
                categoryIndex = -1;  // Reset categoryIndex for the next iteration
            }
            else
            {
                categoryIndex--;  // Convert from 1-based to 0-based index
            }
        }

        entries.Add(new Entry(prompt, response, date, categories[categoryIndex]));
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            Console.WriteLine($"{i+1}. {entry.Date} - {entry.Prompt} - {entry.Response} - Category: {entry.Category}");
        }
    }

    public void DisplayEntriesByCategory(string category)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            if (entry.Category == category)
            {
                Console.WriteLine($"{i+1}. {entry.Date} - {entry.Prompt} - {entry.Response} - Category: {entry.Category}");
            }
        }
    }

    public void DeleteEntry(int index)
    {
        if (index >= 0 && index < entries.Count)
        {
            entries.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index. No entry was deleted.");
        }
    }

    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{entry.Category}");
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
                entries.Add(new Entry(parts[1], parts[2], parts[0], parts[3]));
            }
        }
    }

    public int EntriesCount()
    {
        return entries.Count;
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
            Console.WriteLine("1. Add entry\n2. Display entries\n3. Display entries by category\n4. Delete entry\n5. Save to file\n6. Load from file\n7. Exit");
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
                    Console.WriteLine("Enter category to filter by:");
                    var category = Console.ReadLine();
                    journal.DisplayEntriesByCategory(category);
                    break;
                case "4":
                    if (journal.EntriesCount() > 0)
                    {
                        Console.WriteLine("Enter the index of the entry to delete:");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            journal.DeleteEntry(index-1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No entries to delete.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Enter filename to save:");
                    var saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "6":
                    Console.WriteLine("Enter filename to load:");
                    var loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "7":
                    return;
            }
        }
    }
}


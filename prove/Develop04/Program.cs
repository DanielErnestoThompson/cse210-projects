using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries;
        private Random random;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            random = new Random();
            prompts = new List<string>
            {
                "What was the best part of your day?",
                "Describe a challenge you faced today.",
                "Write about something you learned today.",
                "How did you make someone else happy today?",
                "What's something you're looking forward to?",
                // Add as many prompts as you like...
            };
        }

        public void WriteEntry(string content)
        {
            Entry entry = new Entry(content, DateTime.Now, GetRandomPrompt());
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Content: {entry.Content}\n");
            }
        }

        public void SaveJournal(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.Date);
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Content);
                    writer.WriteLine();
                }
            }
        }

        public void LoadJournal(string filePath)
        {
            entries.Clear();
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    DateTime date = DateTime.Parse(line);
                    string prompt = reader.ReadLine();
                    string content = reader.ReadLine();
                    entries.Add(new Entry(content, date, prompt));
                    reader.ReadLine(); // Skip empty line
                }
            }
        }

        private string GetRandomPrompt()
        {
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }

    public class Entry
    {
        public string Content { get; }
        public DateTime Date { get; }
        public string Prompt { get; }

        public Entry(string content, DateTime date, string prompt)
        {
            Content = content;
            Date = date;
            Prompt = prompt;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            string filePath = "journal.txt";

            // Example usage
            journal.WriteEntry("This is my journal entry.");
            journal.WriteEntry("Another entry for today.");
            journal.SaveJournal(filePath);
            journal.DisplayEntries();

            // Load and display entries from the saved journal
            journal.LoadJournal(filePath);
            journal.DisplayEntries();
        }
    }
}

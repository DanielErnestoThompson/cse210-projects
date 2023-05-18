using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John 3:16");
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.AreAllWordsHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input == "quit")
                break;

            scripture.HideRandomWords();
        }
    }
}

class Scripture
{
    private Reference reference;
    private string text;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = new List<Word>();

        // Split the scripture text into words
        string[] wordArray = text.Split(' ');

        // Initialize Word objects for each word in the scripture text
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine(reference.GetReferenceString() + "\n");
        foreach (Word word in words)
        {
            Console.Write(word.GetWord() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        foreach (Word word in words)
        {
            if (!word.IsHidden() && random.Next(2) == 0)
            {
                word.Hide();
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}

class Reference
{
    private string referenceString;
    private string book;
    private int chapter;
    private List<int> verses;

    public Reference(string referenceString)
    {
        this.referenceString = referenceString;
        ParseReference();
    }

    private void ParseReference()
    {
        string[] parts = referenceString.Split(':');

        if (parts.Length == 2)
        {
            book = parts[0];
            string[] chapterVerse = parts[1].Split(' ');

            int chapterNumber;
            if (int.TryParse(chapterVerse[0], out chapterNumber))
            {
                chapter = chapterNumber;
            }

            if (chapterVerse.Length > 1)
            {
                string[] verseParts = chapterVerse[1].Split(',');
                verses = new List<int>();

                foreach (string versePart in verseParts)
                {
                    int verseNumber;
                    if (int.TryParse(versePart, out verseNumber))
                    {
                        verses.Add(verseNumber);
                    }
                }
            }
        }
        else
        {
            // Handle invalid reference format
            Console.WriteLine("Invalid reference format: " + referenceString);
        }
    }

    public string GetReferenceString()
    {
        return referenceString;
    }

    public string GetBook()
    {
        return book;
    }

    public int GetChapter()
    {
        return chapter;
    }

    public List<int> GetVerses()
    {
        return verses;
    }
}

class Word
{
    private string word;
    private bool hidden;

    public Word(string word)
    {
        this.word = word;
        hidden = false;
    }

    public string GetWord()
    {
        if (hidden)
            return "___";
        else
            return word;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void Hide()
    {
        hidden = true;
    }
}

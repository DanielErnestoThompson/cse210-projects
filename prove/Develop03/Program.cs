using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary();
        ProgressTracker tracker = new ProgressTracker();

        while (true)
        {
            Scripture scripture = library.GetRandomScripture();
            tracker.RecordAttempt(scripture);

            while (!scripture.AreAllWordsHidden())
            {
                Console.Clear();
                scripture.DisplayScripture();
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    tracker.ReportProgress(scripture);
                    break;
                }

                scripture.HideRandomWords();
            }

            if (scripture.AreAllWordsHidden())
                tracker.RecordSuccess(scripture);
        }
    }
}

class ScriptureLibrary
{
    private List<Scripture> scriptures;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Genesis 1:1"), "In the beginning God created the heavens and the earth."),
            new Scripture(new Reference("Proverbs 3:5"), "Trust in the LORD with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("Psalm 23:1"), "The LORD is my shepherd, I lack nothing."),
            new Scripture(new Reference("Matthew 28:19"), "Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit."),
            new Scripture(new Reference("Romans 12:2"), "Do not conform to the pattern of this world, but be transformed by the renewing of your mind. Then you will be able to test and approve what God’s will is—his good, pleasing and perfect will."),
            new Scripture(new Reference("Philippians 4:13"), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("John 14:6"), "Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.'"),
            new Scripture(new Reference("Jeremiah 29:11"), "For I know the plans I have for you,” declares the LORD, “plans to prosper you and not to harm you, plans to give you hope and a future."),
            new Scripture(new Reference("Psalm 46:1"), "God is our refuge and strength, an ever-present help in trouble."),
            new Scripture(new Reference("Isaiah 40:31"), "But those who hope in the LORD will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.")
        };
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
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

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine(reference.GetReferenceString() + "\n");
        foreach (         Word word in words)
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

    public Reference GetReference()
    {
        return reference;
    }
}

class Reference
{
    private string referenceString;

    public Reference(string referenceString)
    {
        this.referenceString = referenceString;
    }

    public string GetReferenceString()
    {
        return referenceString;
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

class ProgressTracker
{
    private Dictionary<string, int> attempts;
    private Dictionary<string, int> successes;

    public ProgressTracker()
    {
        attempts = new Dictionary<string, int>();
        successes = new Dictionary<string, int>();
    }

    public void RecordAttempt(Scripture scripture)
    {
        string refStr = scripture.GetReference().GetReferenceString();
        if (attempts.ContainsKey(refStr))
            attempts[refStr]++;
        else
            attempts[refStr] = 1;
    }

    public void RecordSuccess(Scripture scripture)
    {
        string refStr = scripture.GetReference().GetReferenceString();
        if (successes.ContainsKey(refStr))
            successes[refStr]++;
        else
            successes[refStr] = 1;
    }

    public void ReportProgress(Scripture scripture)
    {
        string refStr = scripture.GetReference().GetReferenceString();
        int attemptCount = attempts.ContainsKey(refStr) ? attempts[refStr] : 0;
        int successCount = successes.ContainsKey(refStr) ? successes[refStr] : 0;

        Console.WriteLine("\nScripture: " + refStr);
        Console.WriteLine("Attempts: " + attemptCount);
        Console.WriteLine("Successes: " + successCount);
        Console.WriteLine("Success Rate: " + (successCount / (float)attemptCount * 100) + "%");
    }
}

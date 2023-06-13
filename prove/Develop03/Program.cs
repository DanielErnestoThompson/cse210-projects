using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static Random random = new Random();

    public static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture("Matthew 11:28-30", "Come unto me, all ye that labour and are heavy laden, and I will give you rest.\nTake my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls.\nFor my yoke is easy, and my burden is light."),
            new Scripture("John 3:5", "Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, he cannot enter into the kingdom of God."),
            new Scripture("John 7:17", "If any man will do his will, he shall know of the doctrine, whether it be of God, or whether I speak of myself."),
            new Scripture("1 Corinthians 11:11", "Nevertheless neither is the man without the woman, neither the woman without the man, in the Lord."),
            new Scripture("1 Corinthians 6:19-20", "What? know ye not that your body is the temple of the Holy Ghost which is in you, which ye have of God, and ye are not your own?\nFor ye are bought with a price: therefore glorify God in your body, and in your spirit, which are God's."),
            new Scripture("Ephesians 1:10", "That in the dispensation of the fulness of times he might gather together in one all things in Christ, both which are in heaven, and which are on earth; even in him:"),
            new Scripture("Matthew 5:14-16", "Ye are the light of the world. A city that is set on an hill cannot be hid.\nNeither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house.\nLet your light so shine before men, that they may see your good works, and glorify your Father which is in heaven.")
        };

        Console.WriteLine("Press Enter to start or type 'quit' to exit.");
        Console.ReadLine();

        int currentScriptureIndex = -1;
        bool showNextScripture = true;

        while (showNextScripture)
        {
            Console.Clear();

            if (currentScriptureIndex == -1)
            {
                currentScriptureIndex = random.Next(scriptures.Count);
            }
            else
            {
                Console.WriteLine("Want to move on to the next scripture? (yes/no/quit)");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "yes")
                {
                    currentScriptureIndex = (currentScriptureIndex + 1) % scriptures.Count;
                }
                else if (userInput.ToLower() == "no")
                {
                    scriptures[currentScriptureIndex].ResetHiddenWords();
                }
                else if (userInput.ToLower() == "quit")
                {
                    break;
                }
            }

            var currentScripture = scriptures[currentScriptureIndex];
            currentScripture.IncrementCount();

            Console.WriteLine($"Scripture Count: {currentScripture.Count}");
            Console.WriteLine(currentScripture.GetFormattedScripture());
            Console.WriteLine("Press Enter to hide the next word or type 'quit' to exit.");

            bool hideNextWord = true;
            string input;

            while (hideNextWord)
            {
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                currentScripture.HideNextWord();
                Console.WriteLine(currentScripture.GetVisibleScripture());

                if (currentScripture.AllWordsHidden())
                {
                    Console.WriteLine("All words hidden. Do you want to move on to the next scripture? (yes/no/quit)");
                    input = Console.ReadLine();

                    if (input.ToLower() == "yes")
                    {
                        currentScriptureIndex = (currentScriptureIndex + 1) % scriptures.Count;
                        currentScripture = scriptures[currentScriptureIndex];
                        currentScripture.IncrementCount();
                        Console.WriteLine($"Scripture Count: {currentScripture.Count}");
                        Console.WriteLine(currentScripture.GetFormattedScripture());
                    }
                    else if (input.ToLower() == "no")
                    {
                        currentScripture.ResetHiddenWords();
                        Console.WriteLine(currentScripture.GetVisibleScripture());
                        Console.WriteLine("Press Enter to hide the next word or type 'quit' to exit.");
                    }
                    else if (input.ToLower() == "quit")
                    {
                        break;
                    }
                }
            }
        }
    }

    private class Scripture
    {
        private string reference;
        private string text;
        private List<string> words;
        private int currentWordIndex;

        private int count;

        public int Count { get { return count; } }

        public void IncrementCount()
        {
            count++;
        }

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            words = new List<string>(text.Split(' '));
            currentWordIndex = -1;
        }

        public void HideNextWord()
        {
            currentWordIndex++;

            if (currentWordIndex < words.Count)
            {
                words[currentWordIndex] = new string('_', words[currentWordIndex].Length);
            }
        }

        public void ResetHiddenWords()
        {
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = text.Split(' ')[i];
            }

            currentWordIndex = -1;
        }

        public string GetVisibleScripture()
        {
            StringBuilder visibleScriptureBuilder = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                visibleScriptureBuilder.Append(words[i]);

                if (i < words.Count - 1)
                {
                    visibleScriptureBuilder.Append(" ");
                }
            }

            return visibleScriptureBuilder.ToString();
        }

        public bool AllWordsHidden()
        {
            return currentWordIndex >= words.Count - 1;
        }

        public string GetFormattedScripture()
        {
            return $"{reference}\n{text}";
        }
    }
}


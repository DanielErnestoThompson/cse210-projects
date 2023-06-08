using System;
using System.Collections.Generic;

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

    public Reference GetReference()
    {
        return reference;
    }
}

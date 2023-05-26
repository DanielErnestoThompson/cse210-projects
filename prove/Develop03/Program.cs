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

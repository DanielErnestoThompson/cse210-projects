using System;

class Program
{
    static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary();
        ProgressTracker tracker = new ProgressTracker();

        bool exitProgram = false;

        while (!exitProgram)
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
                    if (scripture.AreAllWordsHidden())
                        tracker.RecordSuccess(scripture);

                    tracker.ReportProgress(scripture);
                    exitProgram = true;
                    break;
                }

                scripture.HideRandomWords();
            }

            if (!exitProgram && scripture.AreAllWordsHidden())
                tracker.RecordSuccess(scripture);
        }
    }
}

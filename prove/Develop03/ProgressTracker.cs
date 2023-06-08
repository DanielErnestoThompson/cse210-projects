internal class ProgressTracker
{
    internal void RecordAttempt(Scripture scripture)
    {
        throw new NotImplementedException();
    }

    internal void RecordSuccess(Scripture scripture)
    {
        throw new NotImplementedException();
    }

    internal void ReportProgress(Scripture scripture)
    {
        throw new NotImplementedException();
    }
}

internal class Reference
{
    private string v;

    public Reference(string v)
    {
        this.v = v;
    }

    internal string GetReferenceString()
    {
        throw new NotImplementedException();
    }
}

internal class Word
{
    private string word;

    public Word(string word)
    {
        this.word = word;
    }

    internal string GetWord()
    {
        throw new NotImplementedException();
    }

    internal void Hide()
    {
        throw new NotImplementedException();
    }

    internal bool IsHidden()
    {
        throw new NotImplementedException();
    }
}
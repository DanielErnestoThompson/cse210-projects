public abstract class MindfulnessActivity
{
    protected int _durationInSeconds { get; private set; }
    protected string _activityName { get; private set; }
    protected string _description { get; private set; }

    public MindfulnessActivity(int durationInSeconds, string activityName, string description)
    {
        _durationInSeconds = durationInSeconds;
        _activityName = activityName;
        _description = description;
    }

    protected void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}...");
        Console.WriteLine($"{_description}");
        Console.WriteLine($"The activity will last for {_durationInSeconds} seconds.");
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(5);
    }

    protected void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed the {_activityName} for {_durationInSeconds} seconds.");
        ShowCountdown(5);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.WriteLine(i + "..."); 
            Thread.Sleep(1000);
        }
    }

    public abstract void PerformActivity();
}

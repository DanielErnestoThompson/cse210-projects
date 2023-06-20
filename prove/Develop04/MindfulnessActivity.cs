public abstract class MindfulnessActivity
{
    protected int DurationInSeconds { get; set; }
    protected string ActivityName { get; set; }
    protected string Description { get; set; }

    public MindfulnessActivity(int durationInSeconds)
    {
        DurationInSeconds = durationInSeconds;
    }

    protected void StartActivity()
    {
        Console.WriteLine($"Starting {ActivityName}...");
        Console.WriteLine($"{Description}");
        Console.WriteLine($"The activity will last for {DurationInSeconds} seconds.");
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(5);
    }

    protected void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed the {ActivityName} for {DurationInSeconds} seconds.");
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
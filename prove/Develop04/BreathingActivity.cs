
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int durationInSeconds) 
        : base(durationInSeconds, "Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly.")
    {
    }

    public override void PerformActivity()
    {
        StartActivity();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _durationInSeconds)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(2);
            Console.WriteLine("Breathe out...");
            ShowCountdown(2);
        }
        EndActivity();
    }
}


public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int durationInSeconds) : base(durationInSeconds)
    {
        ActivityName = "Breathing Activity";
        Description = "This activity will help you relax by walking your through breathing in and out slowly.";
    }

    public override void PerformActivity()
    {
        StartActivity();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < DurationInSeconds)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(2);
            Console.WriteLine("Breathe out...");
            ShowCountdown(2);
        }
        EndActivity();
    }
}

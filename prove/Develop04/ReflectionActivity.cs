
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _reflectionPrompts;
    private Random _random;

    public ReflectionActivity(int durationInSeconds) 
        : base(durationInSeconds, "Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _reflectionPrompts = new List<string> 
        { 
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need."
        };
        _random = new Random();
    }

    public override void PerformActivity()
    {
        StartActivity();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _durationInSeconds)
        {
            int promptIndex = _random.Next(_reflectionPrompts.Count);
            Console.WriteLine(_reflectionPrompts[promptIndex]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        EndActivity();
    }
}

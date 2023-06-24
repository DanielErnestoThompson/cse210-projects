
public class ListingActivity : MindfulnessActivity
{
    private List<string> _listingPrompts;
    private Random _random;

    public ListingActivity(int durationInSeconds) 
        : base(durationInSeconds, "Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?"
        };
        _random = new Random();
    }

    public override void PerformActivity()
    {
        StartActivity();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _durationInSeconds)
        {
            int promptIndex = _random.Next(_listingPrompts.Count);
            Console.WriteLine(_listingPrompts[promptIndex]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        EndActivity();
    }
}

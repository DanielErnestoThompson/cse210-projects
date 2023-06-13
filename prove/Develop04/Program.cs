using System;
using System.Collections.Generic;
using System.Threading;

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

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _reflectionPrompts;
    private Random _random;

    public ReflectionActivity(int durationInSeconds) : base(durationInSeconds)
    {
        ActivityName = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
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
        while ((DateTime.Now - startTime).TotalSeconds < DurationInSeconds)
        {
            int promptIndex = _random.Next(_reflectionPrompts.Count);
            Console.WriteLine(_reflectionPrompts[promptIndex]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        EndActivity();
    }
}

public class ListingActivity : MindfulnessActivity
{
    private List<string> _listingPrompts;
    private Random _random;

    public ListingActivity(int durationInSeconds) : base(durationInSeconds)
    {
        ActivityName = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
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
        while ((DateTime.Now - startTime).TotalSeconds < DurationInSeconds)
        {
            int promptIndex = _random.Next(_listingPrompts.Count);
            Console.WriteLine(_listingPrompts[promptIndex]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        EndActivity();
    }
}

class MindfulnessApp
{
    public void Run()
    {
        int userChoice;
        int duration;

        while (true)
        {
            Console.WriteLine("Welcome to the Mindfulness App. Choose an activity:\n1. Breathing\n2. Reflection\n3. Listing\n0. Exit");
            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Enter the duration in seconds for the Breathing activity:");
                    duration = int.Parse(Console.ReadLine());
                    BreathingActivity ba = new BreathingActivity(duration);
                    ba.PerformActivity();
                    break;

                case 2:
                    Console.WriteLine("Enter the duration in seconds for the Reflection activity:");
                    duration = int.Parse(Console.ReadLine());
                    ReflectionActivity ra = new ReflectionActivity(duration);
                    ra.PerformActivity();
                    break;

                case 3:
                    Console.WriteLine("Enter the duration in seconds for the Listing activity:");
                    duration = int.Parse(Console.ReadLine());
                    ListingActivity la = new ListingActivity(duration);
                    la.PerformActivity();
                    break;

                case 0:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option! Try again.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MindfulnessApp app = new MindfulnessApp();
        app.Run();
    }
}

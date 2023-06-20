class MindfulnessApp
{
    public void Run()
    {
        int userChoice;
        int duration;

        while (true)
        {
            Console.WriteLine("Welcome to the Mindfulness App. Choose an activity:\n1. Breathing\n2. Reflection\n3. Listing\n0. Exit");

            // Error handling for userChoice
            if (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Enter the duration in seconds for the Breathing activity:");
                    // Error handling for duration
                    if (!int.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid input! Please enter a number.");
                        continue;
                    }
                    BreathingActivity ba = new BreathingActivity(duration);
                    ba.PerformActivity();
                    break;

                case 2:
                    Console.WriteLine("Enter the duration in seconds for the Reflection activity:");
                    // Error handling for duration
                    if (!int.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid input! Please enter a number.");
                        continue;
                    }
                    ReflectionActivity ra = new ReflectionActivity(duration);
                    ra.PerformActivity();
                    break;

                case 3:
                    Console.WriteLine("Enter the duration in seconds for the Listing activity:");
                    // Error handling for duration
                    if (!int.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid input! Please enter a number.");
                        continue;
                    }
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

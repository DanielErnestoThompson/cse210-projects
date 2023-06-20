
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
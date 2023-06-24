public class Program
{
    static User currentUser;
    static void Main(string[] args)
    {
        currentUser = new User("John Doe");

        // Load goals from file (if available)
        currentUser.LoadGoals("goals.txt");

        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Mark a goal as complete");
            Console.WriteLine("3. Display goals and score");
            Console.WriteLine("4. Exit");

            Console.Write("Enter an option: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                continue;
            }

            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    MarkGoalComplete();
                    break;
                case 3:
                    DisplayGoalsAndScore();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }

        } while (option != 4);

        // Save goals to file before exiting
        currentUser.SaveGoals("goals.txt");
    }


    private static void CreateGoal()
    {
        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter reward points:");
        int rewardPoints = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter goal type (1 for Simple, 2 for Eternal, 3 for Checklist):");
        int type = Convert.ToInt32(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case 1:
                goal = new SimpleGoal(description, rewardPoints);
                break;
            case 2:
                goal = new EternalGoal(description, rewardPoints);
                break;
            case 3:
                Console.WriteLine("Enter required completions:");
                int requiredCompletions = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter bonus points:");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());

                goal = new ChecklistGoal(description, rewardPoints, requiredCompletions, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid type");
                return;
        }

        currentUser.AddGoal(goal);
        Console.WriteLine("Goal added successfully");
        Console.ReadLine();
    }

    private static void MarkGoalComplete()
    {
        DisplayGoalsAndScore();

        Console.WriteLine("Enter goal number to mark as complete:");
        if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > currentUser.Goals.Count)
        {
            Console.WriteLine("Invalid goal number");
            return;
        }

        Goal goal = currentUser.Goals[goalIndex - 1];
        Console.WriteLine($"You selected goal {goalIndex}: {goal.Description}. Mark as complete? (1 for yes, 2 for no)");

        if (!int.TryParse(Console.ReadLine(), out int confirm) || confirm < 1 || confirm > 2)
        {
            Console.WriteLine("Invalid selection");
            return;
        }

        if (confirm == 1)
        {
            currentUser.MarkGoalComplete(goal);
            Console.WriteLine("Goal marked as complete successfully");
        }
        else
        {
            Console.WriteLine("Action cancelled");
        }
    }

    private static void DisplayGoalsAndScore()
    {
        Console.WriteLine($"User: {currentUser.Username}, Score: {currentUser.Score}");
        foreach (Goal goal in currentUser.Goals)
        {
            Console.WriteLine($"ID: {goal.Id}, Description: {goal.Description}, Completed: {goal.Completed}, Reward Points: {goal.RewardPoints}");
        }
        Console.ReadLine();
    }
}

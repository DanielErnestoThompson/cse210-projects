using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Goal
{
    public Guid Id { get; }
    public string Description { get; set; }
    public bool Completed { get; protected set; }
    public int RewardPoints { get; protected set; }

    public Goal(string description, int rewardPoints)
    {
        Id = Guid.NewGuid();
        Description = description;
        RewardPoints = rewardPoints;
        Completed = false;
    }

    public abstract void MarkComplete();
    public abstract int GetReward();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string description, int rewardPoints) : base(description, rewardPoints) { }

    public override void MarkComplete()
    {
        this.Completed = true;
    }

    public override int GetReward()
    {
        return this.Completed ? this.RewardPoints : 0;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string description, int rewardPoints) : base(description, rewardPoints) { }

    public override void MarkComplete()
    {
        this.Completed = true;
    }

    public override int GetReward()
    {
        return this.RewardPoints;
    }
}

public class ChecklistGoal : Goal
{
    private int CompletionCount { get; set; }
    private int RequiredCompletions { get; set; }
    private int BonusPoints { get; set; }

    public ChecklistGoal(string description, int rewardPoints, int requiredCompletions, int bonusPoints) : base(description, rewardPoints)
    {
        CompletionCount = 0;
        RequiredCompletions = requiredCompletions;
        BonusPoints = bonusPoints;
    }

    public override void MarkComplete()
    {
        CompletionCount++;
        this.Completed = CompletionCount >= RequiredCompletions;
    }

    public override int GetReward()
    {
        if (!this.Completed) 
        {
            return this.RewardPoints;
        }
        else 
        {
            return this.RewardPoints + BonusPoints;
        }
    }
}

public class User
{
    public Guid Id { get; }
    public string Username { get; set; }
    public int Score { get; private set; }
    public List<Goal> Goals { get; private set; }

    public User(string username)
    {
        Id = Guid.NewGuid();
        Username = username;
        Score = 0;
        Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public bool RemoveGoal(Goal goal)
    {
        return Goals.Remove(goal);
    }

    public void MarkGoalComplete(Goal goal)
    {
        goal.MarkComplete();
        Score += goal.GetReward();
    }
}

public class Program
{
    static User currentUser;
    static void Main(string[] args)
    {
        currentUser = new User("John Doe");

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
            option = Convert.ToInt32(Console.ReadLine());

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
            }

        } while (option != 4);
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
        Console.WriteLine("Enter goal ID:");
        Guid id = Guid.Parse(Console.ReadLine());

        Goal goal = currentUser.Goals.FirstOrDefault(g => g.Id == id);
        if (goal != null)
        {
            currentUser.MarkGoalComplete(goal);
            Console.WriteLine("Goal marked as complete successfully");
        }
        else
        {
            Console.WriteLine("Goal not found");
        }
        Console.ReadLine();
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

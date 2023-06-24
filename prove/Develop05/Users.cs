using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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

    public void SaveGoals(string filePath)
    {
        List<string> serializedGoals = Goals.Select(goal => goal.Serialize()).ToList();
        File.WriteAllLines(filePath, serializedGoals);
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            List<string> serializedGoals = File.ReadAllLines(filePath).ToList();
            Goals = serializedGoals.Select(Goal.Deserialize).ToList();
        }
        else
        {
            Console.WriteLine("Goals file not found.");
        }
    }
}

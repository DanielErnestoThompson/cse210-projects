using System;
using System.Text.Json;

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

    public virtual string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Goal Deserialize(string serializedGoal)
    {
        return JsonSerializer.Deserialize<Goal>(serializedGoal);
    }
}

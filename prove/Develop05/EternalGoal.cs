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

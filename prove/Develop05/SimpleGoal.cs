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

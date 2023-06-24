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

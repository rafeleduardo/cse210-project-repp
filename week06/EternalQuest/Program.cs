/// <summary>
/// Exceeding Requirements: Gamification - Leveling System
/// This program includes a simple leveling system to enhance user engagement.
/// - The user's current level is displayed with their score.
/// - The level is calculated based on the total score (1 new level per 1000 points).
/// - When a user's score crosses the threshold for a new level, a congratulatory
///   message is displayed to celebrate their achievement.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

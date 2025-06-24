[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public float score;

    public LeaderboardEntry(string name, float score)
    {
        this.playerName = name;
        this.score = score;
    }
}

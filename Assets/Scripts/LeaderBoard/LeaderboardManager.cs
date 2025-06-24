using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;
    private List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
    private const int MaxEntries = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<LeaderboardEntry> GetEntries()
    {
        return entries.OrderByDescending(e => e.score).ToList();
    }

    public bool IsHighScore(float score)
    {
        return entries.Count < MaxEntries || score > entries.Min(e => e.score);
    }

    public void AddEntry(string name, float score)
    {
        entries.Add(new LeaderboardEntry(name, score));
        entries = entries.OrderByDescending(e => e.score).Take(MaxEntries).ToList();
        Save();
    }

    private void Save()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            PlayerPrefs.SetString($"LB_Name_{i}", entries[i].playerName);
            PlayerPrefs.SetFloat($"LB_Score_{i}", entries[i].score);
        }
        PlayerPrefs.Save();
    }

    private void Load()
    {
        entries.Clear();
        for (int i = 0; i < MaxEntries; i++)
        {
            if (PlayerPrefs.HasKey($"LB_Name_{i}"))
            {
                string name = PlayerPrefs.GetString($"LB_Name_{i}");
                float score = PlayerPrefs.GetFloat($"LB_Score_{i}");
                entries.Add(new LeaderboardEntry(name, score));
            }
        }
    }
}

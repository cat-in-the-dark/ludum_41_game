using System;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text TextScore;

    // Use this for initialization
    void Awake()
    {
        Show();
    }

    void Start()
    {
        Show();
    }

    public void Show()
    {
        if (!PlayerPrefs.HasKey("Score") || TextScore == null) return;

        var score = PlayerPrefs.GetInt("Score");
        TextScore.text = string.Format("{0}", score);
    }

    public void Save(int score)
    {
        try
        {
            if (PlayGamesPlatform.Instance.localUser.authenticated)
            {
                // Note: make sure to add 'using GooglePlayGames'
                PlayGamesPlatform.Instance.ReportScore(score,
                    GPGSIds.leaderboard_high_score,
                    (bool success) =>
                    {
                        Debug.LogFormat("Leaderboard update success: {0} for user {1}",
                            success, PlayGamesPlatform.Instance.localUser.userName);
                    });
            }
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("Something is wrong with saving leaderboard results: {0}", e);
        }
        
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
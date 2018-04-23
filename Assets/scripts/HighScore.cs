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
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
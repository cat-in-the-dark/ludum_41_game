using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text TextTimeScore;
    public Text TextPlayedTime;
    public float TimeScore;

    private float PainTime = 10;
    private float MissTime = 3;
    private float PriseTime = 5;

    public readonly float InitialTimeCredit = 30;
    private float PlayedTime;
    private HighScore _score;

    // Use this for initialization
    void Start()
    {
        PlayedTime = 0;
        TimeScore = InitialTimeCredit;
        _score = GetComponent<HighScore>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayedTime += Time.deltaTime;
        TimeScore -= Time.deltaTime;

        TextTimeScore.text = string.Format("{0}", (int) TimeScore);
        TextPlayedTime.text = string.Format("{0}", (int) PlayedTime);

        if (TimeScore <= 0)
        {
            Die();
        }
    }

    public void Hurt()
    {
        TimeScore -= PainTime;
    }

    public void Pay()
    {
        TimeScore += PriseTime;
    }

    public void Miss()
    {
        TimeScore -= MissTime;
    }

    private void Die()
    {
        _score.Save(Mathf.FloorToInt(PlayedTime));
        Invoke("GameOver", 0.5f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }
}
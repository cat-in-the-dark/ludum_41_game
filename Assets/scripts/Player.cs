using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int MaxHp = 10;
    private int PainAmount = 1;

    private int PlusScore = 3;
    private int MinusScore = 2;

    public int CurrentHp;
    public int Score;

    public Text TextCurrentHp;
    public Text TextScore;

    // Use this for initialization
    void Start()
    {
        CurrentHp = MaxHp;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextCurrentHp.text = string.Format("{0}", CurrentHp);
        TextScore.text = string.Format("{0}", Score);
    }

    public void Hurt()
    {
        CurrentHp -= PainAmount;
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    public void Pay()
    {
        Score += PlusScore;
    }

    public void Miss()
    {
        Score -= MinusScore;
    }

    public void Die()
    {
        Debug.Log("Dead!");
        Invoke("GameOver", 1);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }
}
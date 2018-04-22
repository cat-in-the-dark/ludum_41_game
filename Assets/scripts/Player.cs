using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float MaxHp = 20f;
	public float PainAmount = 1f;
	private float _currentHp;

	// Use this for initialization
	void Start ()
	{
		_currentHp = MaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt()
	{
		_currentHp -= PainAmount;
		if (_currentHp <= 0)
		{
			Die();
		}
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

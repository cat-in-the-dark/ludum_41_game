using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHighScore : MonoBehaviour {

	public void ToHightScore()
	{
		SceneManager.LoadScene("Scenes/HighScore");
	}
	
}

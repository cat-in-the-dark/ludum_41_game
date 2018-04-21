using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float MaxHp = 100f;
	public float PainAmount = 10f;
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
	}
}

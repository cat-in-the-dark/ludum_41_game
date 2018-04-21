using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {
	public Camera Camera;
	public float ShakeDurationSeconds = 2f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float ShakeAmount = 0.7f;
	public float DecreaseFactor = 1.0f;
	
	private float _shakeDuration = 0f;
	private Vector3 _originalPos;
	private Transform _transform;

	public void Shake()
	{
		_shakeDuration = ShakeDurationSeconds;
	}

	// Use this for initialization
	void Start ()
	{
		_transform = Camera.transform;
		_originalPos = Camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_shakeDuration > 0)
		{
			_transform.localPosition = _originalPos + Random.insideUnitSphere * ShakeAmount;
			_shakeDuration -= Time.deltaTime * DecreaseFactor;
		}
		else
		{
			_shakeDuration = 0f;
			_transform.localPosition = _originalPos;
		}
	}
}

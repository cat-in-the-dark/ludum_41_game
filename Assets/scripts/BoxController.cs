using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float Speed = 1f;
    public string Type;
    public bool IsDead = false; 

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed;
    }

    public void Die()
    {
        IsDead = true;
    }
}
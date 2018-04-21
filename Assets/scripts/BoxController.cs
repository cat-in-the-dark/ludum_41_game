using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float ZSpeed = 1f;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * ZSpeed;
    }
}
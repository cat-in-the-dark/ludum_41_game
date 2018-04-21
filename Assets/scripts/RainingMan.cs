using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingMan : MonoBehaviour
{
    public float EverySecondSpawn = 1;
    public GameObject Enemy;
    public float Z = 40;
    public float MinSpeed = 0.1f;
    public float MaxSpeed = 0.8f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", EverySecondSpawn, EverySecondSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Spawn()
    {
        Debug.Log("BUM");
        var enemy = Instantiate(Enemy);
        var x = Random.Range(-10f, 10f);
        var y = Random.Range(-4f, 4f);
        var pos = new Vector3(x, y, Z);
        enemy.GetComponent<Transform>().position = pos;
        enemy.GetComponent<BoxController>().ZSpeed = Random.Range(MinSpeed, MaxSpeed);
    }
}
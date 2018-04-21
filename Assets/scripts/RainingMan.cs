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
    private readonly List<GameObject> _enemies = new List<GameObject>();
    private CameraShaker _cameraShaker;
    private Player _player;

    // Use this for initialization
    void Start()
    {
        _player = GetComponent<Player>();
        _cameraShaker = GetComponent<CameraShaker>();
        InvokeRepeating("Spawn", EverySecondSpawn, EverySecondSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        // it's safe way to remove elements from the list while iterating over
        for (var i = _enemies.Count - 1; i >= 0; i--)
        {
            var enemy = _enemies[i];
            if (!enemy.GetComponent<BoxController>().IsBehindScene()) continue;
            
            _enemies.Remove(enemy);
            OnBoxHit(enemy);
            Destroy(enemy);
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(Enemy);
        var x = Random.Range(-10f, 10f);
        var y = Random.Range(-4f, 4f);
        var pos = new Vector3(x, y, Z);
        enemy.GetComponent<Transform>().position = pos;
        enemy.GetComponent<BoxController>().ZSpeed = Random.Range(MinSpeed, MaxSpeed);
        _enemies.Add(enemy);
    }

    private void OnBoxHit(GameObject enemy)
    {
        if (_cameraShaker != null) _cameraShaker.Shake();
        _player.Hurt();
    }
}
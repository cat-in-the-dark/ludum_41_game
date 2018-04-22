using System.Collections.Generic;
using UnityEngine;

public class RainingMan : MonoBehaviour
{
    public GameObject EscapeGate;
    public GameObject Enemy;
    public List<float> EverySecondSpawnPerLevel = new List<float>() {0.5f, 0.5f, 0.2f};
    public List<float> SpeedsPerLevel = new List<float>() {0.1f, 0.4f, 0.6f};
    public int CurrentLevel = 0;
    
    private float EverySecondSpawn
    {
        get { return EverySecondSpawnPerLevel[Mathf.Min(CurrentLevel, EverySecondSpawnPerLevel.Count - 1)]; }
    }

    private float Speed
    {
        get { return SpeedsPerLevel[Mathf.Min(CurrentLevel, SpeedsPerLevel.Count - 1)]; }
    }

    private readonly List<GameObject> _enemies = new List<GameObject>();
    private CameraShaker _cameraShaker;
    private Player _player;
    private Vector3 _spawnPoint;
    private Vector3 _escapePoint;

    // Use this for initialization
    void Start()
    {
        _escapePoint = EscapeGate.transform.position;
        _spawnPoint = transform.position;
        _player = GetComponent<Player>();
        _cameraShaker = GetComponent<CameraShaker>();
        InvokeRepeating("Spawn", EverySecondSpawn, EverySecondSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Speed;
        // it's safe way to remove elements from the list while iterating over
        for (var i = _enemies.Count - 1; i >= 0; i--)
        {
            var enemy = _enemies[i];
            enemy.GetComponent<BoxController>().Speed = speed;
            if (!IsEscaped(enemy)) continue;

            _enemies.RemoveAt(i);
            OnEscape(enemy);
            Destroy(enemy);
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(Enemy);
        enemy.GetComponent<Transform>().position = _spawnPoint;
        enemy.GetComponent<BoxController>().Speed = Speed;
        _enemies.Add(enemy);
    }

    private void OnEscape(GameObject enemy)
    {
        var controller = enemy.GetComponent<BoxController>();
        if (controller.IsDead) return; // It's good
        if (_cameraShaker != null) _cameraShaker.Shake();
        _player.Hurt();
    }

    private bool IsEscaped(GameObject enemy)
    {
        return _escapePoint.x < enemy.transform.position.x;
    }
}
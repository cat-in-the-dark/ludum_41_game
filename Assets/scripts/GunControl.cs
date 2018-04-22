using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public float CooldownSeconds = 0.001f;
    public GameObject L;
    public GameObject S;
    public GameObject T;
    public GameObject I;
    private readonly Dictionary<string, GameObject> _objects = new Dictionary<string, GameObject>();
    private readonly string[] _types = {"L", "T", "S", "I"};

    private GameObject _bullet;
    private string _currentType;

    private bool _isAbleToFire;

    // Use this for initialization
    void Start()
    {
        _objects["L"] = L;
        _objects["S"] = S;
        _objects["T"] = T;
        _objects["I"] = I;

        _isAbleToFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_bullet == null)
        {
            NextBullet();
        }

        if (Input.GetMouseButtonDown(0) && _isAbleToFire)
        {
            _isAbleToFire = false;
            Invoke("AllowFire", CooldownSeconds);

            Destroy(_bullet);
            Fire(_currentType);
            _bullet = null;
            _currentType = null;
        }
    }

    private void AllowFire()
    {
        _isAbleToFire = true;
    }

    private void NextBullet()
    {
        var type = _types[Random.Range(0, _types.Length)];
        var obj = Instantiate(_objects[type]);
        obj.transform.parent = transform;
        obj.transform.eulerAngles = Vector3.back * 90;
        obj.transform.position = transform.position;

        _bullet = obj;
        _currentType = type;
    }

    private void Fire(string type)
    {
        var obj = Instantiate(_objects[type]);
        obj.GetComponent<Bullet>().IsFired = true;
        obj.GetComponent<Bullet>().Type = type;
        obj.transform.position = transform.position;
        obj.transform.eulerAngles = Vector3.up; // TODO from mouse position
    }
}
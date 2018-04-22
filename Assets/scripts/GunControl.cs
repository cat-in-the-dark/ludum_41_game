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
        }
    }

    private void AllowFire()
    {
        _isAbleToFire = true;
    }

    private void NextBullet()
    {
        string type;
        do
        {
            // So we never get 2 same types in raw
            type = _types[Random.Range(0, _types.Length)];
        } while (type == _currentType);

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
        var bullet = obj.GetComponent<Bullet>();
        bullet.IsFired = true;
        bullet.Type = type;
        bullet.Direction = AimVector();
        obj.transform.position = transform.position;
        obj.transform.eulerAngles = Vector3.up; // TODO from mouse position
    }

    private float Angle()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    private Vector3 AimVector()
    {
        var angle = Angle();
        return new Vector3(
            Mathf.Cos(Mathf.Deg2Rad * angle),
            Mathf.Sin(Mathf.Deg2Rad * angle),
            0f);
    }
}
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float Speed = 1f;
    public string Type;
    public bool IsDead = false;

    public Sprite DefaultSprite;
    public Sprite MissSprite;
    public Sprite DeadSprite;

    private float ResetSpriteCooldown = 1;
    private SpriteRenderer _renderer;

    private BoxFiller _filler;
    private Player _player;

    // Use this for initialization
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _filler = GetComponent<BoxFiller>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed;
    }

    public void Die()
    {
        CancelInvoke("ResetSprite");
        IsDead = true;
        _renderer.sprite = DeadSprite;
        _filler.RemoveAllCubes();
    }

    public void Miss()
    {
        _renderer.sprite = MissSprite;
        Invoke("ResetSprite", ResetSpriteCooldown);
        
        _player.Miss();
    }

    private void ResetSprite()
    {
        _renderer.sprite = DefaultSprite;
    }
}
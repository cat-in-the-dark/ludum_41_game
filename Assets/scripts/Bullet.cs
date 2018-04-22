using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Type; // L, S, T, I
    public bool IsFired = false;
    public float Speed = 0.5f;
    public Vector3 Direction;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }
        var controller = other.gameObject.GetComponent<BoxController>();
        if (controller.IsDead) return; // nothing to do here
        
        if (controller.Type == Type)
        {
            Hit(controller);
        }
        else
        {
            Miss(controller);
        }
    }

    private void Hit(BoxController controller)
    {
        controller.Die();    
    }

    private void Miss(BoxController controller)
    {
        controller.Miss();
    }
}
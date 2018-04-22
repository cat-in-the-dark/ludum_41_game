using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Type; // L, S, T, I
    public bool IsFired = false;
    public float Speed = 0.5f;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.eulerAngles * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.gameObject.GetComponent<BoxController>();
//        Debug.LogFormat("Collide between {0}, {1}", Type, controller.Type);
        
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
        Debug.Log("MISS");    
    }
}
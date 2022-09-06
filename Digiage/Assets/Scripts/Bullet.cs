using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}

using UnityEngine;

public class Orb : MonoBehaviour
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
        if (hitInfo != null)
        {
            if (hitInfo.name.Equals("Enemy"))
            {
                hitInfo.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        if (!hitInfo.name.Equals("Player")) Destroy(gameObject);
    }

}

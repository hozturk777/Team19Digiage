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
        
        if (hitInfo != null)
        {
            if (hitInfo.gameObject.tag=="Player")
            {   
                
                hitInfo.GetComponent<Player>().TakeDamage(damage);

            }
        }
        if (hitInfo.gameObject.tag!="Enemy")      
            Destroy(gameObject);
    }

}

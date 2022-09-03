using UnityEngine;

public class AiChase : MonoBehaviour
{

    public GameObject target;
    public float speed;
    public float distanceBetween;
    public float firstSight;
    private float distance;
    private Rigidbody2D rb;

    // Start Boxis called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance<firstSight)
        {
            if (distance > distanceBetween + 1)
            {
                //transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                rb.velocity = new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.y - this.transform.position.y) * speed;
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else if (distance < distanceBetween - 1)
            {
                rb.velocity = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y) * speed;
                //transform.position = Vector2.MoveTowards(this.transform.position, (this.transform.position-target.transform.position)+this.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * -angle);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}

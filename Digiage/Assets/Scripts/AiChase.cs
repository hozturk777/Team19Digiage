using UnityEngine;

public class AiChase : MonoBehaviour
{
    private AnimationController animationController;
    public GameObject target;
    public float speed;
    public float distanceBetween;
    public float firstSight;
    private float distance;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 direction;

    // Start Boxis called before the first frame update
    void Start()
    {
        animationController = GetComponent<AnimationController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void Chase()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < firstSight)
        {
            if (distance > distanceBetween + 1)
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.y - this.transform.position.y) * speed * Time.fixedDeltaTime;

            }
            else if (distance < distanceBetween - 1)
            {
                direction = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y);
                direction.Normalize();
                rb.velocity = direction * speed * Time.fixedDeltaTime;
                
            }
            else
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = Vector2.zero;
            }
        }
        Color color = new Color(0, 0, 1.0f);
        Debug.DrawLine(this.transform.position, new Vector3(direction.x,direction.y,0), color);
        animationController.WalkAnimation(animator,direction);
        
    }

    
}

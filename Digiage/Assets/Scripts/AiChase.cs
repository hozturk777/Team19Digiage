using UnityEngine;

public class AiChase : MonoBehaviour
{
    private EnemyAnimationController enemyAnimationController;
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
        enemyAnimationController = GetComponent<EnemyAnimationController>();
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
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
            }
            {
                direction = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y);
                rb.velocity = direction * speed * Time.fixedDeltaTime;
            }
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        //Color color = new Color(0, 0, 1.0f);
        //Debug.DrawLine(this.transform.position, new Vector3(direction.x,direction.y,0), color);

        if (rb.velocity != Vector2.zero)
            enemyAnimationController.WalkAnimation(animator,direction);
        else
            enemyAnimationController.AttackAnimation(animator,direction);
        
    }

    
}

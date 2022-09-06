using UnityEngine;

public class AiChase : MonoBehaviour
{
    private float enemyNextAttackTime;
    private float distance;
    private Rigidbody2D rb;
    private AnimationController animationController;
    private Animator animator;
    private Vector2 direction;
    public Transform firePoint;
    public GameObject target;
    public GameObject bulletPrefab;
    public float firePointRange;
    public float speed;
    public float distanceBetween;
    public float firstSight;
    public float enemyAttackRate;

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
        if (target.GetComponent<Player>().isAlive())
        {
            Chase();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Chase()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);


        if (distance < firstSight)
        {
            if (distance > distanceBetween + 0.25f)
            {
                direction = (target.transform.position - transform.position).normalized;
                rb.velocity = direction * speed * Time.fixedDeltaTime;

            }
            else if (distance < distanceBetween - 0.25f)
            {
                direction = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y).normalized;
                rb.velocity = direction * speed * Time.fixedDeltaTime;

            }
            else if (!target.GetComponent<Walk>().IsWalking())
            {
                direction = (target.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                firePoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                rb.velocity = Vector2.zero;
                if (Time.time >= enemyNextAttackTime)
                {
                    AttackToPlayer();
                    enemyNextAttackTime = Time.time + 1f / enemyAttackRate;
                }
            }
            firePoint.position = new Vector3(transform.position.x,transform.position.y-.15f,transform.position.z) + (new Vector3(direction.x, direction.y, 0) * firePointRange);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


        animationController.WalkAnimation(animator, direction);

    }

    private void AttackToPlayer()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmos()
    {
        if (firePoint == null)
            return;


        Gizmos.DrawWireSphere(firePoint.position, .2f);
    }

}

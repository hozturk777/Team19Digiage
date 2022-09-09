using UnityEngine;
using Pathfinding;

public class AiChase : MonoBehaviour
{
    private float enemyNextAttackTime;
    private float distance;
    private Rigidbody2D rb;
    private AnimationController animationController;
    private Animator animator;
    private Vector2 direction;
    private Transform firePoint;
    public AIPath aIPath;
    public GameObject target;
    public GameObject bulletPrefab;
    public float firePointRange=0.3f;
    public float speed;
    public float distanceBetween;
    public float firstSight;
    public float enemyAttackRate=3f;

    // Start Boxis called before the first frame update
    void Start()
    {
        firePoint = this.transform.Find("FirePoint");
        animationController = GetComponent<AnimationController>();
        animator = GetComponentInChildren<Animator>();
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
            direction=Vector2.zero;
            animationController.AiAttackAnimation(animator, direction, false);
            animationController.WalkAnimation(animator,direction);
            rb.velocity = Vector2.zero;
        }
    }

    private void Chase()
    {
        if (!float.IsInfinity(aIPath.remainingDistance))
            distance = aIPath.remainingDistance;
        else distance = (target.transform.position - transform.position).magnitude;
        if (distance < firstSight)
        {

            if (distance > distanceBetween + 0.3f)
            {
                animationController.AiAttackAnimation(animator, direction, false);
                aIPath.enabled = true;
                //Debug.DrawRay(transform.position, aIPath.desiredVelocity.normalized, Color.red);
                direction = aIPath.desiredVelocity.normalized.normalized;
            }
            else if (distance < distanceBetween - 0.3f)
            {
                animationController.AiAttackAnimation(animator, direction, false);
                aIPath.enabled = false;
                direction = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y).normalized;
                rb.velocity = direction * speed * Time.fixedDeltaTime;

            }
            else if (!target.GetComponent<Walk>().IsWalking())
            {
                
                direction = (target.transform.position-transform.position).normalized;
                Debug.DrawRay(transform.position, direction, Color.magenta);
                //Debug.DrawRay(transform.position, direction, Color.red);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                firePoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                rb.velocity = Vector2.zero;
                if (Time.time >= enemyNextAttackTime)
                {
                    animationController.AiAttackAnimation(animator, direction, true);
                    AttackToPlayer();
                    enemyNextAttackTime = Time.time + 1f / enemyAttackRate;
                }
            }
            firePoint.position = new Vector3(transform.position.x,transform.position.y-GetComponent<BoxCollider2D>().offset.y,transform.position.z) + (new Vector3(direction.x, direction.y, 0) * firePointRange);
            Debug.DrawRay(transform.position, aIPath.desiredVelocity.normalized, Color.black,.2f);
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        Debug.DrawRay(transform.position, direction*3, Color.magenta);
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

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private AnimationController animationController;
    private Rigidbody2D rb;
    private Animator attackAnimator;
    private Transform attackPoint;
    public Camera camera;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public float attackPointRange = 0.16f;
    public int attackDamage = 35;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    [SerializeField] private AudioSource PlayerAttackSound;

    Vector2 mousePos;

    private void Awake()
    {
        attackPoint = this.transform.Find("AttackPoint");
        animationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
        attackAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - rb.position).normalized;
        attackPoint.position = this.transform.position + (new Vector3(lookDir.x, lookDir.y, 0) * attackPointRange);

        if (Input.GetMouseButton(0))
        {
            if(!PlayerAttackSound.isPlaying)
            PlayerAttackSound.Play();
            animationController.AttackAnimation(attackAnimator, lookDir, true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animationController.AttackAnimation(attackAnimator, lookDir, false);
        }

        if (Time.time >= nextAttackTime && Input.GetMouseButton(0))
        {

            Attack(lookDir);
            nextAttackTime = Time.time + 1f / attackRate;
        }
           
        

    }

    private void Attack(Vector2 lookDir)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
     
       
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

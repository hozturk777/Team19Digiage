using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private AnimationController animationController;
    private Rigidbody2D rb;
    private Animator attackAnimator;
    private Transform meleeAttackPoint;
    private Transform rangeAttackPoint;
    public GameObject vfx;
    public Camera mainCamera;
    public LayerMask enemyLayers;
    public GameObject bulletPrefab;
    public float attackRange = 0.4f;
    public float meleeAttackPointRange = 0.16f;
    public float rangeAttackPointRange = 0.16f;
    public int attackDamage = 35;
    public int healQuantity = 10;
    public float attackRate = 2f;
    public float skillRate = 0.5f;
    float nextMeleeAttackTime = 0f;
    float nextRangeAttackTime = 0f;
    float nextSkillTime = 0f;

    Vector2 mousePos;

    private void Awake()
    {
        vfx.SetActive(false);
        rangeAttackPoint = this.transform.Find("RangeAttackPoint");
        meleeAttackPoint = this.transform.Find("MeleeAttackPoint");
        animationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
        attackAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - rb.position).normalized;
        meleeAttackPoint.position = this.transform.position + (new Vector3(lookDir.x, lookDir.y, 0) * meleeAttackPointRange);
        rangeAttackPoint.position = this.transform.position + (new Vector3(lookDir.x, lookDir.y, 0) * rangeAttackPointRange);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rangeAttackPoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        meleeAttackPoint.transform.Find("AttackEffect").rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //Ýf else içerisindeki koþullarý animasyonlar le kontrol et eðer animasyonlar karýþýrsa
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            animationController.AttackAnimation(attackAnimator, lookDir, true);
            vfx.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0)&&!Input.GetMouseButtonUp(1))
        {
            animationController.AttackAnimation(attackAnimator, lookDir, false);
            vfx.SetActive(false);
        }

        if (Time.time >= nextMeleeAttackTime && Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            MeleeAttack(lookDir);
            nextMeleeAttackTime = Time.time + 1f / attackRate;
        }
        //Sað mouse basýlý ise animasyonu oynatmak için true ver 


        //Sað mouse tuþundan elini çektiðinden animasyonu durdurmak için false ver


        //Sað mouse attack fonksiyonunu çaðýr
        if (Time.time >= nextRangeAttackTime && Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            RangeAttack();
            nextRangeAttackTime = Time.time + 1f / attackRate;
        }

        //Sað-sol mouse basýldýðýnda yetenek animasyonu true olacak

        //Sað-sol mouse basýldýðýnda yetenek animasyonu false olacak

        //Sað-sol mouse basýldýðýnda yetenek fonksiyonunu çaðýr
        if (Time.time>=nextSkillTime && Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            SpecialSkill();
            nextSkillTime = Time.time + 1f / skillRate;
        }

    }

    private void MeleeAttack(Vector2 lookDir)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeAttackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
       
    }

    private void OnDrawGizmos()
    {
        if (meleeAttackPoint == null)
            return;


        Gizmos.DrawWireSphere(meleeAttackPoint.position, attackRange);
    }

    private void RangeAttack()
    {
        Instantiate(bulletPrefab, rangeAttackPoint.position, rangeAttackPoint.rotation);
    }

    private void SpecialSkill()
    {
        GetComponent<Player>().TakeHeal(healQuantity);
    }
}

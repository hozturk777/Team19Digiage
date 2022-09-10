using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private AnimationController animationController;
    private Rigidbody2D rb;
    private Animator attackAnimator;
    private Transform meleeAttackPoint;
    private Transform rangeAttackPoint;
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
    float nextSkillTime = 0f;
    [SerializeField] private AudioSource HitSound;
    [SerializeField] private AudioSource HealSound;

    Vector2 mousePos;

    private void Awake()
    {
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
        //�f else i�erisindeki ko�ullar� animasyonlar le kontrol et e�er animasyonlar kar���rsa
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {   
            if (!HitSound.isPlaying){
                HitSound.Play();
            }
            animationController.AttackAnimation(attackAnimator, lookDir, true);
        }
        if (Input.GetMouseButtonUp(0)&&!Input.GetMouseButtonUp(1))
        {
            if(HitSound.isPlaying)
                HitSound.Stop();
            animationController.AttackAnimation(attackAnimator, lookDir, false);
        }

        if (Time.time >= nextMeleeAttackTime && Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            MeleeAttack(lookDir);
            nextMeleeAttackTime = Time.time + 1f / attackRate;
        }
        //Sa� mouse bas�l� ise animasyonu oynatmak i�in true ver 


        //Sa� mouse tu�undan elini �ekti�inden animasyonu durdurmak i�in false ver


        //Sa� mouse attack fonksiyonunu �a��r
        /*if (Time.time >= nextRangeAttackTime && Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            RangeAttack();
            nextRangeAttackTime = Time.time + 1f / attackRate;
        }*/

        //Sa�-sol mouse bas�ld���nda yetenek animasyonu true olacak
        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {   
            if (!HealSound.isPlaying){
                HealSound.Play();
            }
            animationController.HealAnimation(attackAnimator,true);
        }
         //Sa�-sol mouse bas�ld���nda yetenek animasyonu false olacak
        if (Input.GetMouseButtonUp(1)&&!Input.GetMouseButtonUp(0))
        {
            if(HealSound.isPlaying)
                HealSound.Stop();
            animationController.HealAnimation(attackAnimator,false);
        }
        //Sa�-sol mouse bas�ld���nda yetenek fonksiyonunu �a��r
        if (Time.time>=nextSkillTime && Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            SpecialSkill();
            nextSkillTime = Time.time + skillRate;
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

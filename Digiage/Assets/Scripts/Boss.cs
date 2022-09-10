using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float enemyNextAttackTime;
    private float distance;
    private AnimationController animationController;
    private Animator animator;
    private Transform firePoint;
    private float reloadTime;
    public GameObject target;
    public GameObject bulletPrefab;
    public float firstSight;
    public float enemyAttackRate = 3f;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = this.transform.Find("FirePoint");
        animationController = GetComponent<AnimationController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<Player>().isAlive())
        {
            Attack();
        }
        else
        {
            animationController.BossAttackAnimation(animator, false);
        }
    }

    private void Attack()
    {
        distance = (target.transform.position - transform.position).magnitude;

        if (distance < firstSight)
        {
            if (Time.time >= enemyNextAttackTime)
            {
                canAttack = true;
                enemyNextAttackTime = Time.time + enemyAttackRate;
                reloadTime = Time.time + enemyAttackRate / 2;
            }
            else if(Time.time>= reloadTime)
            {
                canAttack = false;
                animationController.BossAttackAnimation(animator, false);
            }
            if (canAttack)
            {
                animationController.BossAttackAnimation(animator, true);
                AttackToPlayer();
            }
        }
    }

    private void AttackToPlayer()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

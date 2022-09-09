using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private AnimationController animationController;
    private Animator animator;
    int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<AnimationController>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play Hurt animation

        if (currentHealth <= 0)
        {
            //animator.SetBool("Dead1", true);
            animationController.AiDieAnimation(animator, true);
            Die();
        }
    }

    void Die()
    {
        //Die animation
        
        Debug.Log("Enemy Died!!");
        //Disable the enemy
        GetComponentInChildren<Canvas>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AiChase>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<AIDestinationSetter>().enabled = false;
        this.enabled = false;
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private AnimationController animationController;
    private Animator animator;
    public HealthBar healthBar;

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Die();
        }
    }

    public void TakeHeal(int heal)
    {
        if (currentHealth<100)
        {
            currentHealth += heal % 100;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void Die()
    {
        animationController.DieAnimation(animator,true);
        GetComponentInChildren<Canvas>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Walk>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }

    public bool isAlive()
    {
        if (currentHealth<=0)
        {
            return false;
        }
        return true;
    }
}

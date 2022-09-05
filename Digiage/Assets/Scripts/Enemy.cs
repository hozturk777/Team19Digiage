using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play Hurt animation

        if (currentHealth<=0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die animation
        Debug.Log("Enemy Died!!");
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
}

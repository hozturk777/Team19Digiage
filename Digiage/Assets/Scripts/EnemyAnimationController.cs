using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public void WalkAnimation(Animator animator, Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        animator.SetBool("Attack", false);
    }
    public void AttackAnimation(Animator animator, Vector2 direction)
    {
        animator.SetFloat("Speed", 0);
        animator.SetBool("Attack", true);
    }
}

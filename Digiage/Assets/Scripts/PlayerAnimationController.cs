using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public void WalkAnimation(Animator animator, Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    public void AttackAnimation(Animator animator, Vector2 direction)
    {
        animator.SetFloat("HorizontalAttack", direction.x);
        animator.SetFloat("VerticalAttack", direction.y);
        if (Input.GetMouseButtonDown(0))
            animator.SetBool("Attack1", true);
        if (Input.GetMouseButtonUp(0))
            animator.SetBool("Attack1", false);
        if (Input.GetMouseButtonDown(1))
            animator.SetBool("Attack2", true);
        if (Input.GetMouseButtonUp(1))
            animator.SetBool("Attack2", false);
    }
   
}

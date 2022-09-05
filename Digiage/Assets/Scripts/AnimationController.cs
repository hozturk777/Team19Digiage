using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void WalkAnimation(Animator animator,Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    public void AttackAnimation(Animator animator,Vector2 direction,bool isPressed)
    {
        animator.SetFloat("HorizontalAttack", direction.x);
        animator.SetFloat("VerticalAttack", direction.y);
        animator.SetBool("Attack", isPressed);
        /*if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack",true);  
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attack", false);
        }*/
        
    }
}

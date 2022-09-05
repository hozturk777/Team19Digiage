using UnityEngine;

public class AnimationController : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    
=======
=======
>>>>>>> parent of 278a091 (Duzenleme)
    public void WalkAnimation(Animator animator,Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
<<<<<<< HEAD
>>>>>>> parent of 6c7e4c0 (Merge pull request #2 from catcoder03/Mert)
=======

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
>>>>>>> parent of 278a091 (Duzenleme)
}

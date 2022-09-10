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
    }

    public void DieAnimation(Animator animator,bool isPressed)
    {
        animator.SetTrigger("Dead1");
    }

    public void AiAttackAnimation(Animator animator,Vector2 direction,bool isPressed)
    {
        animator.SetFloat("HorizontalAttackAi", direction.x);
        animator.SetFloat("VerticalAttackAi", direction.y);
        animator.SetBool("AttackAi", isPressed);
    }

    public void AiDieAnimation(Animator animator, bool isPressed)
    {
        animator.SetBool("Dead1", isPressed);
        animator.SetBool("Dead2", isPressed);
    }

    public void BossAttackAnimation(Animator animator,bool attack)
    {
        animator.SetBool("Attack", attack);
    }
}

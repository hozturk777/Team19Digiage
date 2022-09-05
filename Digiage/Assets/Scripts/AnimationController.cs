using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
<<<<<<< HEAD
    
=======
    public void WalkAnimation(Animator animator,Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
>>>>>>> parent of 6c7e4c0 (Merge pull request #2 from catcoder03/Mert)
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator attackAnimator;
    public Camera camera;
    private AnimationController animationController;

    Vector2 mousePos;
    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
        attackAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        lookDir.Normalize();

        // animationController.AttackEnemyAnimation(attackAnimator, lookDir);
    }
}

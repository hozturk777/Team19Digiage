using UnityEngine;

public class Walk : MonoBehaviour
{
    private PlayerAnimationController playerAnimationController;
    private AnimationController animationController;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimationController = GetComponent<PlayerAnimationController>();
        animationController = GetComponent<AnimationController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(Horizontal, Vertical);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerAnimationController.WalkAnimation(animator, movement);
        animationController.WalkAnimation(animator, movement);
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);
    }
}

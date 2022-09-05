using UnityEngine;

public class Walk : MonoBehaviour
{
    private AnimationController animationController;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
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

        
        animationController.WalkAnimation(animator, movement);
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);
    }
}

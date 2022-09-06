using UnityEngine;

public class Walk : MonoBehaviour
{
    private AnimationController animationController;
    public float moveSpeed = 3f;
    public float moveSpeed2 = 3f;
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
        PlayerMove();
        PlayerMove2();
    }

    private void PlayerMove()
    {
        
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(Horizontal, Vertical);


        animationController.WalkAnimation(animator, movement);
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);
        
    }
    private void PlayerMove2()
    {
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Vertical = Input.GetAxisRaw("Vertical");

            movement = new Vector2(Horizontal, Vertical);


            animationController.WalkAnimation(animator, movement);
            rb.velocity = new Vector2(movement.x * moveSpeed2 * Time.fixedDeltaTime, movement.y * moveSpeed2 * Time.fixedDeltaTime);
        }

    }

    public bool IsWalking()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            return true;
        }
        else return false;
    }
}

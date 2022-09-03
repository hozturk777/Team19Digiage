using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xInput;
    private float yInput;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    public Animator animator;


    Vector3 ScalePlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScalePlayer = transform.localScale;
       
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        var moveVector = new Vector3(xInput, yInput, 0);
        //rb.MovePosition(new Vector2(this.transform.position.x + moveVector.x * speed * Time.deltaTime, this.transform.position.y + moveVector.y * speed * Time.deltaTime));
        rb.velocity = new Vector2(moveVector.x * speed , moveVector.y * speed );

        if (xInput > 0)
        {
            transform.localScale = new Vector3(ScalePlayer.x, ScalePlayer.y, ScalePlayer.z);
        }
        else if (xInput < 0)
        {
            transform.localScale = new Vector3(-ScalePlayer.x, ScalePlayer.y, ScalePlayer.z);
        }
    }
}

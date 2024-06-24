using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool isGround;
    float movement;
    int flip;


    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Get();
    }

    private void Get()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Povorot();
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    private void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            anim.SetBool("Jumping", false);
        }
        else
        {
            anim.SetBool("Jumping", true);
        }
    }

    void Povorot()
    {
        sr.flipX = flip < 0;
        if (Input.GetKey(KeyCode.D))
        {
            flip = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            flip = -1;
        }    
    }

}

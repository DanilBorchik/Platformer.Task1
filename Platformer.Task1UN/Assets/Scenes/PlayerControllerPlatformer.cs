using UnityEngine;
using UnityEngine.Animations;

public class PlayerControllerPlatformer : MonoBehaviour
{
    public float speed = 1f;
    public float boost;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float timerforpritazhenie;
    private float timerforpritazheniePrivate;
    public float pritazhenieNew;
    private float pritazhenieNewPrivate;
    private bool isGround;
    float movement;
    float coyoteTime = 0.3f;
    float coyoteTimeCounter;
    int flip;
    public AudioSource jump;


    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Get();
    }

    private void Get()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Povorot();
    }
    private void FixedUpdate()
    {
        Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        isGround = colider.Length > 1;
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);

        if (movement != 0)
        {
            if (speed < 9f)
            {
                speed += boost * Time.deltaTime;
            }
        }
        else
        {
            speed = 5;
        }
        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    private void Jump()
    {
        if (isGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        if (isGround == true)
        {
            anim.SetBool("Jumping", false);
            pritazhenieNewPrivate = pritazhenieNew;
            rb.gravityScale = 0.1f;
            timerforpritazheniePrivate = timerforpritazhenie;
        }
        else
        {
            timerforpritazheniePrivate -= Time.deltaTime;
            if (timerforpritazheniePrivate <= 0)
            {
                rb.gravityScale = pritazhenieNewPrivate;
            }
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

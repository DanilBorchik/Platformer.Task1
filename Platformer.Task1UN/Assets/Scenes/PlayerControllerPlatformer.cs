using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float timerforpritazhenie;
    private float timerforpritazheniePrivate;
    public float pritazhenieNew;
    private float pritazhenieNewPrivate;
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
        Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        isGround = colider.Length > 1;
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    private void Jump()
    {
        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
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

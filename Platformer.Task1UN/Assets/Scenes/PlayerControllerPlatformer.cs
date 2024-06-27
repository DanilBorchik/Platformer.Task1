using UnityEngine;
public class PlayerControllerPlatformer : MonoBehaviour
{
    [SerializeField] private savedPosition lastSavedPosition;
    public float speed = 1f;
    public float boost;
    public float jumpForce = 5f;
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    public float timerforpritazhenie;
    private float _timerforpritazheniePrivate;
    public float pritazhenieNew;
    private float pritazhenieNewPrivate;
    private bool isGround;
    float movement;
    float coyoteTime = 0.3f;
    float coyoteTimeCounter;
    int flip;
    public AudioSource jump;
    public AudioSource fail;
    
    private Animator anim;
 
    void Start()
    {
        transform.position = lastSavedPosition.position + Vector3.down*0.7f;
        Get();
    }

    private void Get()
    {
        _rb = GetComponent<Rigidbody2D>();
      
        _sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Povorot();
    }
    private void FixedUpdate()
    {
        Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        isGround = colider.Length > 1;
        Move();

        if (transform.position.y <= -10)
        {
            fail.Play();
            Start();
        }
        
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movement * speed * Time.fixedDeltaTime, 0, 0));

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
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            jump.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        if (isGround)
        {
            anim.SetBool("Jumping", false);
            pritazhenieNewPrivate = pritazhenieNew;
            _rb.gravityScale = 0.1f;
            _timerforpritazheniePrivate = timerforpritazhenie;
        }
        else
        {
            _timerforpritazheniePrivate -= Time.deltaTime;
            if (_timerforpritazheniePrivate <= 0)
            {
                _rb.gravityScale = pritazhenieNewPrivate;
            }
            anim.SetBool("Jumping", true);
            
        }

    }

    void Povorot()
    {
        _sr.flipX = flip < 0;
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

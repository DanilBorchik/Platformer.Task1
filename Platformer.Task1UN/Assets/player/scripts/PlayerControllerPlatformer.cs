using fishscripts;
using UnityEngine;
using static fishscripts.shcriptos;
public class PlayerControllerPlatformer : MonoBehaviour
{
    public savedPosition lastSavedPosition;
    [SerializeField] float speed = 1f;
    [SerializeField] float boost;
    [SerializeField] float jumpForce = 5f;
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    [SerializeField] float timerforpritazhenie;
    private float _timerforpritazheniePrivate;
    [SerializeField] float pritazhenieNew;
    private float pritazhenieNewPrivate;
    private bool isGround;
    [SerializeField] float movement;
    float coyoteTime = 0.3f;
    float coyoteTimeCounter;
    int flip;
    int colvoJump;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource fail;
    private ParticleSystem jumpParticles;
    private Animator anim;
 
    void Start()
    {
        lastSavedPosition.position = transform.position+Vector3.up*0.7f;
        Get();
    }

    private void Get()
    {
        _rb = GetComponent<Rigidbody2D>();
      
        _sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        jumpParticles = GetComponentInChildren<ParticleSystem>();
    }
    
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
            transform.position = lastSavedPosition.position + Vector3.down * 0.7f;
            _rb.velocity = new Vector2(0, 0);
        }
        
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A)&Input.GetKey(KeyCode.D)&isGround)
        {
            movement = 0;
        }
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
        anim.SetFloat("moveX", Mathf.Abs(movement));
    }

    private void Jump()
    {
        if (isGround)
        {
            colvoJump = 1;
        }
        if (coyoteTimeCounter > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                colvoJump = 2;
                coyoteTimeCounter = 0;
            }
        }
        CoyoteTim();
        if (coyoteTimeCounter > 0 || colvoJump > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                
                jump.Play();
                jumpParticles.Play();
                _rb.gravityScale = 0.1f;
                _timerforpritazheniePrivate = timerforpritazhenie;
                if (colvoJump == 1)
                {
                    anim.SetTrigger("doublejump");
                    jumpParticles.Play();
                }
                colvoJump--;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0;
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

    private void CoyoteTim()
    {
        if (isGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void Povorot()
    {
        if (!Input.GetKey(KeyCode.A)|!Input.GetKey(KeyCode.D))
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

}

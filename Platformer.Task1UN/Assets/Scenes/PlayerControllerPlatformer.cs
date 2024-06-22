using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool isGround;


    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));

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

        sr.flipX = movement < 0 ? true : false;
    }

}

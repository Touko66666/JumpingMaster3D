using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    bool jumpKeysArePressedOn;
    bool leftKeysArePressedOn;
    bool rightKeysArePressedOn;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public float runSpeed;

    public float jumpSpeed;
    public float jumpTime;

    private float jumpTimeCounter;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                leftKeysArePressedOn = true;
            }
            else
            {
                leftKeysArePressedOn = false;
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rightKeysArePressedOn = true;
            }
            else
            {
                rightKeysArePressedOn = false;
            }

            //checking if any keys are pressed on and plays animations
            if (rightKeysArePressedOn)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                spriteRenderer.flipX = false;

                if (isGrounded)
                    animator.Play("player_run");

                if (!isGrounded)
                    animator.Play("player_moveinair");
            }
            else if (leftKeysArePressedOn)
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                spriteRenderer.flipX = true;

                if (isGrounded)
                    animator.Play("player_run");

                if (!isGrounded)
                    animator.Play("player_moveinair");
            }

            //jump scripts starts

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                animator.Play("player_up");

            }
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    if (!(leftKeysArePressedOn || rightKeysArePressedOn))
                    {
                        animator.Play("player_up");
                    }
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            else if (!(leftKeysArePressedOn || rightKeysArePressedOn))
            {
                if (isGrounded)
                    animator.Play("player_idle");
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            if (jumpKeysArePressedOn && !(leftKeysArePressedOn || rightKeysArePressedOn))
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            if (rb2d.velocity.y < 2.5 && !isGrounded && !(leftKeysArePressedOn || rightKeysArePressedOn))
            {
                animator.Play("player_down");
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;
            }
        }
    }
}


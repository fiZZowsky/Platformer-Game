using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    [SerializeField] LayerMask terrainLayer;
    private Animator anim;
    private SpriteRenderer sprite;
    private PolygonCollider2D coll;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpPower = 15f;
    [SerializeField] private int extraJumps = 1;

    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;
    float dirX;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }

        UpdateAnimationState();
        CheckGrounded();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
    }

    void jump()
    {
        if (isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if (IsGrounded())
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private bool IsGrounded()
    {
        Vector2 groundCheckBoxSize = new Vector2(coll.bounds.size.x * 0.9f, 0.05f);

        Vector2 groundCheckBoxCenter = new Vector2(coll.bounds.center.x, coll.bounds.min.y - groundCheckBoxSize.y * 0.5f);

        Collider2D hitCollider = Physics2D.OverlapArea(
            groundCheckBoxCenter - groundCheckBoxSize * 0.5f,
            groundCheckBoxCenter + groundCheckBoxSize * 0.5f,
            terrainLayer);

        return hitCollider != null;
    }
}

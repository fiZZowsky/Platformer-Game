using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    [SerializeField] LayerMask groundLayer;
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;

    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;
    float mx;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        mx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }

        CheckGrounded();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
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
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
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
}

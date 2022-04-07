using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    private Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;

    public Transform groundPoint;

    public LayerMask groundLayer;

    private bool doubleJump;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        if (knockBackCounter <= 0)
        {


            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, groundLayer);

            if (isGrounded)
            {
                doubleJump = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else
                {
                    if (doubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        doubleJump = false;
                    }
                }
            }

            if (theRB.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (theRB.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(spriteRenderer.flipX == false)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
            else
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));

    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);

        animator.SetTrigger("hurt");
    }

}

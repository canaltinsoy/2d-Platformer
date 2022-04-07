using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;

    public SpriteRenderer spriteRenderer;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                spriteRenderer.flipX = true;

                if (transform.position.x >= rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                spriteRenderer.flipX = false;

                if (transform.position.x <= leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = waitTime;
            }
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0)
            {
                moveCount = moveTime;
            }

        }
    }
}

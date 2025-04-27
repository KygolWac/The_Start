using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerGrounded playerGrounded;
    private float moveContorller;
    private bool isRunning = false;
    private bool isIdeling = true;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerGrounded = GetComponentInChildren<PlayerGrounded>();
    }

    // Update is called once per frame
    void Update()
    {

        moveContorller = Input.GetAxisRaw("Horizontal");
        // Debug.Log(moveContorller);
        rb.velocity = new Vector2(moveSpeed * moveContorller, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        OnAnimatorMove();
    }

    private void OnAnimatorMove()
    {
        isRunning = moveContorller != 0;
        anim.SetBool("isRunning", isRunning);
        if (playerGrounded.isGrounded != true)
        {
            if (rb.velocity.y > 0)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isFalling", false);
            }
            else if(rb.velocity.y < 0)
            {
                anim.SetBool("isFalling", true);
                anim.SetBool("isJumping", false);
            }
        } else 
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
    }


}

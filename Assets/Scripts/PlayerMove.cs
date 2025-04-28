using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private PhysicsCheck physicsCheck;
    private float moveContorller;
    private bool isRunning = false;
    public int jumpTimes = 1;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        physicsCheck = GetComponentInChildren<PhysicsCheck>();
    }

    // Update is called once per frame
    void Update()
    {

        moveContorller = Input.GetAxisRaw("Horizontal");
        // Debug.Log(moveContorller);
        rb.velocity = new Vector2(moveSpeed * moveContorller, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTimes > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpTimes--;
            }
        }
        if(rb.velocity.x > 0.02f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(rb.velocity.x < -0.02f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        SetAnimator();
    }

    private void SetAnimator()
    {
        isRunning = moveContorller != 0;
        anim.SetBool("isRunning", isRunning);
        if (physicsCheck.isGrounded)
        {
            jumpTimes = 1;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            
        } else 
        {
            if (rb.velocity.y > 0.1f)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isFalling", false);
            }
            else if (rb.velocity.y < -0.1f)
            {
                anim.SetBool("isFalling", true);
                anim.SetBool("isJumping", false);
            } else
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", false);
            }
        }
    }


}

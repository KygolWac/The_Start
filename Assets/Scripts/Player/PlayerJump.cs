using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update

    private PhysicsCheck physicsCheck;
    private Animator anim;
    private int jumpTimes = 1;
    //[SerializeField] private float jumpForce;
    [SerializeField] private float jumpSpeed;
    void Start()
    {
        anim = GetComponent<Animator>();
        physicsCheck = GetComponentInChildren<PhysicsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTimes > 0)
            {
                // playerRb.AddForce(new Vector2(0, moveForce * moveContorller));
                PlayerMove.playerRb.velocity = new Vector2(PlayerMove.playerRb.velocity.x, jumpSpeed);
                jumpTimes--;
            }
        }
        SetAnimator();
    }

    private void SetAnimator()
    {
        if (physicsCheck.isGrounded)
        {
            jumpTimes = 1;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);

        }
        else
        {
            if (PlayerMove.playerRb.velocity.y > 0.1f)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isFalling", false);
            }
            else if (PlayerMove.playerRb.velocity.y < -0.1f)
            {
                anim.SetBool("isFalling", true);
                anim.SetBool("isJumping", false);
            }
            else
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", false);
            }
        }
    }
}

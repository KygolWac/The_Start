using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpSpeed;
    
    private int jumpTimes = 1;
    private GroundCheck groundCheck;
    private PlayerMove playerMove;
    private Animator anim;
    
    //[SerializeField] private float jumpForce;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJumping();
    }

    private void PlayerJumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTimes > 0)
            {
                // playerRb.AddForce(new Vector2(0, moveForce * moveContorller));
                playerMove.playerRb.velocity = new Vector2(playerMove.playerRb.velocity.x, jumpSpeed);
                jumpTimes--;
            }
        }
        if (groundCheck.isGrounded)
        {
            jumpTimes = 1;
        }
    }

}

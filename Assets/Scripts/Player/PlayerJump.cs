using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private PlayerController moveContorller;
    [SerializeField] 
    private float jumpSpeed;
    [SerializeField]
    private int canJump = 2;
    private float jumpDirection;
    [SerializeField]
    private float cantJumpTime = 0.2f;
    private float currentTime = 0f;
    private GroundCheck groundCheck;
    private PlayerMove playerMove;
    
    //[SerializeField] private float jumpForce;
    
    void Start()
    {
        moveContorller = GetComponent<PlayerController>();
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
        currentTime += Time.deltaTime;
        jumpDirection = moveContorller.inputDiretion.y;
        if (jumpDirection > 0)
        {
            if (canJump > 0 && currentTime > cantJumpTime)
            {
                // playerRb.AddForce(new Vector2(0, moveForce * moveContorller));
                playerMove.playerRb.velocity = new Vector2(playerMove.playerRb.velocity.x, jumpSpeed);
                groundCheck.isGrounded = false;
                canJump --;
                currentTime = 0f;
            }
        }
        if (groundCheck.isGrounded)
        {
            canJump = 2;
        }
    }

}

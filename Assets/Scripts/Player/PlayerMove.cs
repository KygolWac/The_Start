using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    public PlayerController moveContorller;

    [SerializeField]
    private float moveSpeed;
    [SerializeField] 
    private float moveDirection;
    [SerializeField] 
    private float moveForce;
    [SerializeField]
    private SlopeCheck slopeCheck;



    private void Start()
    {
        moveContorller = GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody2D>();
        slopeCheck = GetComponentInChildren<SlopeCheck>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMoving();
        PlayerChangeDiretion();
    }

    private void PlayerChangeDiretion()
    {
        if (playerRb.velocity.x > 0.02f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (playerRb.velocity.x < -0.02f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void PlayerMoving()
    {
        moveDirection = moveContorller.inputDiretion.x;
        //moveContorller = 0;UnityEngine.Input.GetAxisRaw("Horizontal");
        // Debug.Log(moveContorller);
        if (!slopeCheck.isOnSlope)
        {
            playerRb.AddForce(new Vector2(moveForce * moveDirection, 0));
        }else
        {
            playerRb.AddForce
                (
                new Vector2
                    (
                        moveForce * moveDirection * -slopeCheck.slopeNormalPerp.x, 
                        moveForce * moveDirection * -slopeCheck.slopeNormalPerp.y * 0.665f
                    )
                );
        }
        if (Mathf.Abs(playerRb.velocity.x) > moveSpeed)
        {
            playerRb.velocity = new Vector2(moveSpeed * Mathf.Sign(playerRb.velocity.x), playerRb.velocity.y);
        }
    }

    

}

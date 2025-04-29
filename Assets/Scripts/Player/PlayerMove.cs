using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    public static Rigidbody2D playerRb;

    private Animator anim;
    private float moveContorller;
    private bool isRunning = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveForce;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        PlayerChangeDiretion();
        SetAnimator();
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
        moveContorller = Input.GetAxisRaw("Horizontal");
        // Debug.Log(moveContorller);
        //playerRb.velocity = new Vector2(moveSpeed * moveContorller, playerRb.velocity.y);
        playerRb.AddForce(new Vector2(moveForce * moveContorller, 0));
        if (Mathf.Abs(playerRb.velocity.x) > moveSpeed)
        {
            playerRb.velocity = new Vector2(moveSpeed * Mathf.Sign(playerRb.velocity.x), playerRb.velocity.y);
        }
        // playerRb.velocity = new Vector2(Mathf.Min(Mathf.Abs(playerRb.velocity.x), moveSpeed) * moveContorller, playerRb.velocity.y);
    }

    private void SetAnimator()
    {
        isRunning = moveContorller != 0;
        anim.SetBool("isRunning", isRunning);
    }

}

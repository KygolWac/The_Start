using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private enum PlayerState { idle, run, jump, fall, climb};
    private PlayerState playerState;
    private Animator anim;
    private PhysicsCheck physicsCheck;
    private PlayerMove playerMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        physicsCheck = GetComponentInChildren<PhysicsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.moveContorller == 0)
        {
            playerState = PlayerState.idle;
        } else
        {
            playerState = PlayerState.run;
        }
        if(physicsCheck.isGrounded == false)
        {
            if (playerMove.playerRb.velocity.y > 0.2f)
            {
                playerState = PlayerState.jump;
            }
            else if (playerMove.playerRb.velocity.y < -0.2f)
            {
                playerState = PlayerState.fall;
            }
            else
            {
                playerState = PlayerState.fall; // should be state 'climb'
                // 此处应为若条件满足应为蹬墙状态否则为下落状态 蹬墙跳后期会加入
            }
        }
        anim.SetInteger("States", (int)playerState);
    }
}

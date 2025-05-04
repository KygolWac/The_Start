using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private enum PlayerState { idle, run, jump, fall, climb};
    private PlayerState playerState;
    private Animator anim;
    private GroundCheck groundChecker;
    private PlayerMove playerMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        groundChecker = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.moveContorller.inputDiretion.x == 0)
        {
            playerState = PlayerState.idle;
        } else
        {
            playerState = PlayerState.run;
        }
        if(groundChecker.isGrounded == false)
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
                // �˴�ӦΪ����������ӦΪ��ǽ״̬����Ϊ����״̬ ��ǽ�����ڻ����
            }
        }
        anim.SetInteger("States", (int)playerState);
        
    }

}

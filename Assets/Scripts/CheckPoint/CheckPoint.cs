using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool isDone;
    private Animator anim;
    private BoxCollider2D checkpointCollider;
    private PlayerDead playerDead;

    //public UnityEvent<Transform> OnCheckpointSwitched;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        checkpointCollider = GetComponent<BoxCollider2D>();
        playerDead = GameObject.Find("Player").GetComponent<PlayerDead>();
        //pd = collision.GetComponent<PlayerDead>();
    }

    public void TriggerAction()
    {
        CheckpointSet();
    }

    private void CheckpointSet()
    {
        if (isDone)
            return;
        anim.SetTrigger("isCheck");
        isDone = true;
        checkpointCollider.enabled = false;
        //TODO:ÇÐ»»³öÉúµã
        playerDead.checkpointPosition = this.transform.position;
    }

}
  
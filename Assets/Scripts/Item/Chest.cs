using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool isDone = false;
    private BoxCollider2D chestCollider;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        chestCollider = GetComponent<BoxCollider2D>();
    }
    public void TriggerAction()
    {
        OpenChest();
        Debug.Log("Open chest");
    }

    private void OpenChest()
    {
        if (isDone) 
        {
            anim.SetBool("isDone", isDone);
            return;
        }
        anim.SetBool("isOpening", true);
        isDone = true;
        chestCollider.enabled = false;
    }

    
}

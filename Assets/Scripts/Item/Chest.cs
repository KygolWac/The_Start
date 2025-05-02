using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool isDone = false;
    private BoxCollider2D collider2D;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
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
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

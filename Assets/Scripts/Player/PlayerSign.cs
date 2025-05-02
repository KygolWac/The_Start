using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSign : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject signSprite;
    public Transform playerTrans; 
    [SerializeField]
    private bool canPress = false;

    private Animator anim;

    private void Awake()
    {
        // anim = GetComponentInChildren<Animator>();
        anim = signSprite.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Interactable"))
        {
            canPress = false;
        }
    }

    private void Update()
    {
        signSprite.SetActive(canPress);
        signSprite.transform.localScale = playerTrans.localScale;
    }
}

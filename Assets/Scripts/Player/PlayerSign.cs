using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSign : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject signSprite;
    public Transform playerTrans; 
    [SerializeField]
    private bool canPress = false;
    private SpriteRenderer signSpriteRenderer;
    private PlayerInputSystem playerInput;
    private IInteractable targetItem;
    private Animator anim;

    private void Awake()
    {
       // anim = GetComponentInChildren<Animator>();
        anim = signSprite.GetComponent<Animator>();
        signSpriteRenderer = signSprite.GetComponent<SpriteRenderer>();
        
        playerInput = new PlayerInputSystem();
        playerInput.Enable();
    }

    private void OnEnable()
    {
        playerInput.Gameplay.Confirm.started += OnConfirm;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            targetItem = other.GetComponent<IInteractable>();
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
    private void OnConfirm(InputAction.CallbackContext obj)
    {
        if (canPress) 
        {
            targetItem.TriggerAction();
        }
    }

    private void Update()
    {
        signSpriteRenderer.enabled = canPress;
        signSprite.transform.localScale = playerTrans.localScale;
    }
}

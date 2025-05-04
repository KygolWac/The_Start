using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour, IInteractable
{
    public GameObject signSprite;
    private Animator anim;
    private SpriteRenderer bonfireSpriteRenderer;
    private SpriteRenderer flameSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        bonfireSpriteRenderer = GetComponent<SpriteRenderer>();

        flameSpriteRenderer = GameObject.Find("Flame").GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    public void TriggerAction()
    {
        BonfireInteract();
        Debug.Log("Bonfire lit");
    }

    private void BonfireInteract()
    {
        flameSpriteRenderer.enabled = !flameSpriteRenderer.enabled;
        anim.SetBool("isBurning", flameSpriteRenderer.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        bonfireSpriteRenderer.enabled = true;
    }
}

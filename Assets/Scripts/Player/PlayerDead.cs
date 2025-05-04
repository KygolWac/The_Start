using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]
    private float fixedTime;
    private GameObject playerObject;

    //public Transform checkpointTransform;
    public Vector3 checkpointPosition;
    private Rigidbody2D rb;
    private Animator anim;


    private void Awake()
    {
        playerObject = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        checkpointPosition = playerObject.transform.position;
        // checkpointTransform = GetComponent<Transform>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            //TODO:ÕÊº“À¿Õˆ
            Debug.Log("Dead");
            StartCoroutine(DeadProcess());
        }
    }


    private IEnumerator DeadProcess()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(fixedTime);
        
        playerObject.transform.position = checkpointPosition;
        anim.SetTrigger("finishDead");
        yield return new WaitForSeconds(fixedTime);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


}

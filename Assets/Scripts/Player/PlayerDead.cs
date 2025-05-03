using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            //�������
            anim.SetTrigger("isDead");
            rb.bodyType = RigidbodyType2D.Static;//��Ҳ���
        }
    }

    public void reBirth()
    {
        transform.position = pos;//�س�����
        rb.bodyType = RigidbodyType2D.Dynamic;//������ܶ���
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantform : MonoBehaviour
{
    public Transform posA, posB;
    private Transform movePos;
    [SerializeField] 
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movePos = posA;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            movePos = posB;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            movePos = posA;
        }
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, moveSpeed * Time.deltaTime);
    }
}

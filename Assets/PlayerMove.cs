using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D PlayerRb;
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRb.velocity = new Vector2(2, 0);
    }
}

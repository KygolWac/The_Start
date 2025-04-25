using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Transform PlayerTransform;
    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerTransform.position + " " + PlayerTransform.rotation);
        //Debug.Log(_playerTransform.position + " " + _playerTransform.rotation);
    }
}

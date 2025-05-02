using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        Debug.Log("game started");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("game is running");
    }
}

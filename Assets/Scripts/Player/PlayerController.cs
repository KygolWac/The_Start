using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    //private Transform checkpointTransform;
    //private Rigidbody2D rb;
    public PlayerInputSystem inputControl;
    public Vector2 inputDiretion;

    private void Awake()
    {
        Application.targetFrameRate = 60;//锁定最大帧率为60帧
        inputControl = new PlayerInputSystem();
        //Application.targetFrameRate = 30;//锁定最大帧率为30帧
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputDiretion = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }


}

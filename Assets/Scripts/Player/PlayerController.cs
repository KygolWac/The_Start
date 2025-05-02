using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInputSystem inputControl;
    public Vector2 inputDiretion;

    private void Awake()
    {
        Application.targetFrameRate = 60;//�������֡��Ϊ60֡
        inputControl = new PlayerInputSystem();
        //Application.targetFrameRate = 30;//�������֡��Ϊ30֡
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
        
    }

    // Update is called once per frame
    private void Update()
    {
        inputDiretion = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }
}

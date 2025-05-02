using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour, IInteractable
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerAction()
    {
        Debug.Log("Scene switched");
        SwitchScene();
    }

    private void SwitchScene()
    {
        //blablabla
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

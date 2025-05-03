using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour, IInteractable
{
    public SceneLoadEventSO loadEventSO; 
    public Vector3 positionToGo = new Vector3(-36.25f, -12, 0);
    public GameSceneSO sceneToGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerAction()
    {
        Debug.Log("Scene switch");
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

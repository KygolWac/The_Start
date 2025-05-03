using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName ="Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;
    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="locationToLoad">Ҫ���صĳ���</param>
    /// <param name="positionToGo">���������ָ��λ��</param>
    /// <param name="fadeScreenNeeded">�Ƿ���Ҫ���뽥��</param>
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 positionToGo, bool fadeScreenNeeded)
    {
        LoadRequestEvent?.Invoke(locationToLoad, positionToGo, fadeScreenNeeded);
    } 
}
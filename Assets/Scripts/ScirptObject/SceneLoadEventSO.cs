using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName ="Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;
    /// <summary>
    /// 场景加载请求
    /// </summary>
    /// <param name="locationToLoad">要加载的场景</param>
    /// <param name="positionToGo">人物加载至指定位置</param>
    /// <param name="fadeScreenNeeded">是否需要渐入渐出</param>
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 positionToGo, bool fadeScreenNeeded)
    {
        LoadRequestEvent?.Invoke(locationToLoad, positionToGo, fadeScreenNeeded);
    } 
}
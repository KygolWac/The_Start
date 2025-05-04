using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 defualtPosition;

    [Header("�¼�����")]
    public SceneLoadEventSO loadEventSO;

    public GameSceneSO firstLoadScene;
    public float fadeDuration;

    [Header("�㲥")]
    public VoidEventSO afterSceneLoadedEvent;
    public FadeEventSO fadeEvent;

    [SerializeField]
    private GameSceneSO currentLoadScene;
    private GameSceneSO sceneToLoad;
    private Vector3 positonToGo;
    private bool fadeScreenNeeded;
    private bool isLoading;

    private GameObject playerObject;



    private void Awake()
    { 
        /*
        Addressables.LoadSceneAsync
            (
                firstLoadScene.scenceReference, 
                UnityEngine.SceneManagement.LoadSceneMode.Additive
            );
        */
        // currentLoadScene = firstLoadScene;
        // currentLoadScene.scenceReference.LoadSceneAsync(LoadSceneMode.Additive);
        currentLoadScene = null;
    }

    //TODO:���˵����º��ڴ˴��л�����

    private void Start()
    {
        playerObject = GameObject.Find("Player");
        NewGame();
    }

    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
    }

    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }

    private void NewGame()
    {
        sceneToLoad = firstLoadScene;
        //���ó�ʼcheckpoint
        playerObject.GetComponent<PlayerDead>().checkpointPosition = defualtPosition;
        OnLoadRequestEvent(sceneToLoad, defualtPosition, true);
    }
     
    /// <summary>
    /// ���������¼�����
    /// </summary>
    /// <param name="locationToLoad"></param>
    /// <param name="posToGo"></param>
    /// <param name="fadeNeeded"></param>
    private void OnLoadRequestEvent(GameSceneSO locationToLoad, Vector3 posToGo, bool fadeNeeded)
    {
        if (isLoading)
            return;
        isLoading = true;
        sceneToLoad = locationToLoad;
        positonToGo = posToGo;
        fadeScreenNeeded = fadeNeeded;
        playerObject.GetComponent<PlayerDead>().checkpointPosition = posToGo;
        //Debug.Log("Load scene event triggered"); 
        if (currentLoadScene != null)
        {
            StartCoroutine(UnloadPreviousScene());
        }
        else
        {
            LoadNewScene();
        }
    }

    private IEnumerator UnloadPreviousScene()
    {
        if(fadeScreenNeeded)
        {
            //�����𽥱��
            fadeEvent.FadeIn(fadeDuration);
        }

        yield return new WaitForSeconds(fadeDuration);
        
        yield return currentLoadScene.sceneReference.UnLoadScene();
        
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        var loadingOperation = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadingOperation.Completed += OnLoadCompleted;
    }

    /// <summary>
    /// ����������ɺ��¼�����
    /// </summary>
    /// <param name="handle"></param>
    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> handle)
    {
        currentLoadScene = sceneToLoad;

        playerTransform.position = positonToGo;

        playerTransform.gameObject.SetActive(true);

        if (fadeScreenNeeded)
        {
            //������ɳ�����͸��
            fadeEvent.FadeOut(fadeDuration);
        }
        isLoading = false;
        // �����������֮���¼�
        afterSceneLoadedEvent.RaiseEvent();
    }
}

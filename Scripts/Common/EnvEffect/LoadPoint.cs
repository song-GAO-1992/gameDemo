using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadPoint : MonoBehaviour
{

    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    GameObject HDUPrefab;
    [SerializeField]
    GameObject groundPrefab;
    [SerializeField]
    GameObject cameraPrefab;

    //玩家加载坐标
    Transform playerPos;
    Transform cameraPos;

    Scene currentScene;
    int groudIndex;
    void Awake()
    {
        groudIndex = GetCurrentSceneIndex();
        playerPos = transform.Find("PlayerPos");
        cameraPos = transform.Find("CameraPos");
        cameraPrefab = Resources.Load<GameObject>("FreeLookCameraRig") as GameObject;
        playerPrefab = Resources.Load<GameObject>("Player") as GameObject;
        HDUPrefab = Resources.Load<GameObject>("UIPanels/HDU") as GameObject;
        groundPrefab = Resources.Load<GameObject>("Grounds/Level" + groudIndex.ToString()) as GameObject;

        Instantiate<GameObject>(groundPrefab, transform);
        Instantiate<GameObject>(playerPrefab, playerPos);
        Instantiate<GameObject>(cameraPrefab, cameraPos);
        
        

        Instantiate(HDUPrefab);
    }

    int GetCurrentSceneIndex()
    {
        currentScene = SceneManager.GetActiveScene();
        return currentScene.buildIndex - 1;
    }
}

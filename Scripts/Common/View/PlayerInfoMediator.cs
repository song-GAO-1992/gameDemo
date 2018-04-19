using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoMediator : EventMediator
{
    [Inject]
    public PlayerInfoView playerInfoView { get; set; }
    bool isSaveFinished = false;
    Scene currentScene;

    //玩家信息
    string playerData;
    string[] playerDataStr = new string[4];
    int[] playerDataInt = new int[2];

    public override void OnRegister()
    {
        playerInfoView.Init();
        //监听view层
        playerInfoView.dispatcher.AddListener("MoveNextScene", OnMoveNextScene);
        playerInfoView.dispatcher.AddListener("SaveFileClicked", OnSaveButtonClicked);
        playerInfoView.dispatcher.AddListener("OnReturnHomeClicked", OnReturnHomeClicked);
        //监听Command层
        dispatcher.AddListener(PlayerEventsList_C.UpdateInfoBack, UpdatePlayerInfo);
        dispatcher.AddListener(PlayerEventsList_C.DamagedBack, OnPlayerDamagedBack);

        dispatcher.AddListener(GameEvent.SavePlayerInfoCallBack, OnSavePlayerInfoCallBack);
        dispatcher.AddListener(GameEvent.EnterSavePoint, OnEnterSavePoint);

        dispatcher.Dispatch(PlayerEventsList_V.UpdateInfo);
        //获取当前场景信息
        currentScene = SceneManager.GetActiveScene();
    }



    //更新HP、Score信息
    void UpdatePlayerInfo(IEvent iev)
    {
        playerData = iev.data.ToString();
        playerDataStr = playerData.Split('-');
        for (int i = 0; i < playerDataStr.Length - 2; i++)
        {
            playerDataInt[i] = int.Parse(playerDataStr[i]);
        }
        //判断Hp是否为0
        if (playerDataInt[0] <= 0)
        {
            playerInfoView.PlayerDeath();
        }
        playerInfoView.UpdatePlayerInfo(playerDataInt[0], playerDataInt[1]);
    }

    //受伤后的更新
    void OnPlayerDamagedBack()
    {
        //受伤页面的显示
        playerInfoView.FlashDamagePanel();
    }

    //点击保存按钮
    void OnSaveButtonClicked()
    {
        dispatcher.Dispatch(GameEvent.SavePlayerInfo);
    }

    //玩家信息存储回调
    void OnSavePlayerInfoCallBack()
    {
        isSaveFinished = true;
    }

    //移向下一场景
    void OnMoveNextScene()
    {
        if (isSaveFinished == true)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }

    //进入存储点
    void OnEnterSavePoint()
    {
        playerInfoView.ShowSaveFilePanel();
    }

    //返回Home页面
    void OnReturnHomeClicked()
    {
        dispatcher.Dispatch(GameEvent.ReturnHome);
        //SceneManager.LoadScene(0);
    }

}

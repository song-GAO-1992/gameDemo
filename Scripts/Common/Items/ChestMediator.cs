using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMediator : EventMediator
{
    [Inject]
    public ChestView chestView { get; set; }
    int ID;

    public override void OnRegister()
    {
        chestView.Init();
        chestView.dispatcher.AddListener("OpenChest", OnOpenChest);
        chestView.dispatcher.AddListener("AddScore",OnAddScore);
        dispatcher.AddListener(PlayerEventsList_C.ScoreBack, OnScoreCallBack);
    }

    //箱子打开的回调函数
    void OnOpenChest(IEvent iev)
    { 
        dispatcher.Dispatch(PlayerEventsList_V.Score,iev.data);
    }


    void OnScoreCallBack(IEvent iev)
    {
        Debug.Log(iev.data.ToString());
        string[] dataStr = iev.data.ToString().Split('+');
        int id;
        int.TryParse(dataStr[0],out id);
        chestView.FlashScore(id,dataStr[1]);
    }

    void OnAddScore(IEvent iev)
    {
        dispatcher.Dispatch(PlayerEventsList_V.AddScore, iev.data.ToString());
    }
    



}

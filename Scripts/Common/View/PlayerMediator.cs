using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator : EventMediator
{
    //玩家信息(用于OnPlayerInfoUpdate)
    string playerInfo;
    string[] playerInfos;
    bool isHelmetArmed;

    [Inject]
    public PlayerView playerView { get; set; }

    public override void OnRegister()
    {
        //view初始化
        playerView.Init();

        //监听来自view端的事件
        playerView.dispatcher.AddListener("PickEquip", OnPickEquip);
        playerView.dispatcher.AddListener("Attacked", OnPlayerAttacked);

        //监听来自command端的事件
        dispatcher.AddListener(PlayerEventsList_C.UpdateInfoBack, OnPlayerInfoUpdate);
        dispatcher.AddListener(PlayerEventsList_C.UpdateEquipBack, OnPlayerEquipUpdate);
        dispatcher.AddListener(PlayerEventsList_C.UpdateLevelBack, OnUpdatePlayerLevel);
        dispatcher.AddListener(PlayerEventsList_C.DamagedBack, OnPlayerDamagedBack);
    }


    //玩家信息更新
    void OnPlayerInfoUpdate(IEvent iev)
    {
        playerInfo = iev.data.ToString();
        playerInfos = playerInfo.Split('-');
        int[] data = new int[3];
        for (int i = 0; i < playerInfos.Length - 1; i++)
        {
            data[i] = int.Parse(playerInfos[i]);
        }
        bool.TryParse(playerInfos[3], out isHelmetArmed);
        playerView.SetUpPlayerBaseInfo(data[0], data[1], data[2], isHelmetArmed);
    }

    //捡起装备
    void OnPickEquip(IEvent iev)
    {
        dispatcher.Dispatch(PlayerEventsList_V.UpdateEquip, iev.data);
    }

    //玩家装备更新
    void OnPlayerEquipUpdate(IEvent iev)
    {
        bool.TryParse(iev.data.ToString(), out isHelmetArmed);
        playerView.UpdateEquipment(isHelmetArmed);
    }

    //玩家级别更新
    void OnUpdatePlayerLevel(IEvent iev)
    {
        string data = iev.data.ToString();
        playerView.UpdateLevelPanel(data);
    }


    //View检测到玩家收到攻击
    void OnPlayerAttacked()
    {
        dispatcher.Dispatch(PlayerEventsList_V.Damaged);
    }

    //Command返回玩家收到攻击事件的处理结果
    void OnPlayerDamagedBack()
    {
        playerView.PlayerDamaged();
    }


}

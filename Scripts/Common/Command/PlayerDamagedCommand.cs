using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedCommand : EventCommand {

    [Inject]
    public PlayerData playerData { get; set; }
    public override void Execute()
    {
        int damage = Random.Range(5, 20);
        playerData.HP -= damage;
        //判断玩家的HP是否小于0
        if(playerData.HP<=0)
        {
            playerData.HP = 0;
        }
        dispatcher.Dispatch(PlayerEventsList_C.DamagedBack, damage);
        dispatcher.Dispatch(PlayerEventsList_V.UpdateInfo);
    }
}

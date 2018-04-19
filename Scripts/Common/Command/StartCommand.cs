using strange.extensions.command.impl;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : EventCommand {


    [Inject]
    public PlayerData playerData { get; set; }
    //加载，更新玩家信息
    public override void Execute()
    {
        dispatcher.Dispatch(GameEvent.LoadPlayerInfo);
    }


}

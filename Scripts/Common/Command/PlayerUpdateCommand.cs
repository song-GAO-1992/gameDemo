using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Text;

public class PlayerUpdateCommand : EventCommand
{
    [Inject]
    public PlayerData playerData { get; set; }
    StringBuilder dataSB =new StringBuilder();
    public override void Execute()
    {
        Debug.Log(this.GetHashCode());
        dataSB.AppendFormat("{0}-{1}-{2}-{3}", playerData.HP, playerData.Score, playerData.Level, playerData.IsHelmetArmed);
        dispatcher.Dispatch(PlayerEventsList_C.UpdateInfoBack, dataSB.ToString());
    }
}

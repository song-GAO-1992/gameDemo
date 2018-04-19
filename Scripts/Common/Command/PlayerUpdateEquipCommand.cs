using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateEquipCommand : EventCommand
{

    [Inject]
    public PlayerData playerData { get; set; }
    bool res;
    public override void Execute()
    {
        bool.TryParse(evt.data.ToString(), out res);
        if (res)
        {
            playerData.IsHelmetArmed = true;
        }
        else
        {
            playerData.IsHelmetArmed = false;
        }
        playerData.IsHelmetArmed = true;
        dispatcher.Dispatch(PlayerEventsList_C.UpdateEquipBack, playerData.IsHelmetArmed);
    }
}

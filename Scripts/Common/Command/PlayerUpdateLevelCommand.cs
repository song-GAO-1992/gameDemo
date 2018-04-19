using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateLevelCommand : EventCommand
{
    [Inject]
    public PlayerData playerData { get; set; }

    public override void Execute()
    {
        int level = playerData.Level;
        dispatcher.Dispatch(PlayerEventsList_C.UpdateLevelBack, level.ToString());
    }
}

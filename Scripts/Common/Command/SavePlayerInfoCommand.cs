using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerInfoCommand : EventCommand {

    [Inject]
    public PlayerData playerData { get; set; }

    public override void Execute()
    {
        PlayerPrefs.SetInt("Hp", playerData.HP);
        PlayerPrefs.SetInt("Score", playerData.Score);
        PlayerPrefs.SetInt("Level", playerData.Level);
        PlayerPrefs.SetString("IsHelmetArmed", playerData.IsHelmetArmed.ToString());
        dispatcher.Dispatch(GameEvent.SavePlayerInfoCallBack);
    }
}

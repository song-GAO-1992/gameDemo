using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 从PlayerPrefs获取数据，并存储进PlayerData
/// </summary>
public class LoadPlayerInfoCommand : EventCommand {

    [Inject]
    public PlayerData playerData { get; set; }
    public override void Execute()
    {
        playerData.HP = PlayerPrefs.GetInt("Hp");
        playerData.Score = PlayerPrefs.GetInt("Score");
        playerData.Level = PlayerPrefs.GetInt("Level");
        playerData.IsHelmetArmed = bool.Parse(PlayerPrefs.GetString("IsHelmetArmed"));
    }
}

using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJsonCommand : EventCommand
{
    string filePath = Application.dataPath + "/Resources/Json/PlayerData.Json";


    public override void Execute()
    {
        Debug.Log("savejsoncommand");
        PlayerItem playerItem = new PlayerItem();
        Player player = new Player();

        player.Hp = PlayerPrefs.GetInt("Hp");
        player.Score = PlayerPrefs.GetInt("Score");
        player.Level = PlayerPrefs.GetInt("Level");
        player.IsHelmetArmed = bool.Parse(PlayerPrefs.GetString("IsHelmetArmed"));
        //清空PlayerPrefs中的数据
        PlayerPrefs.DeleteAll();

        playerItem.data.Add(player);
        string data = JsonUtility.ToJson(playerItem);
        FileInfo fileInfo = new FileInfo(filePath);
        StreamWriter SW = fileInfo.CreateText();
        SW.WriteLine(data);
        SW.Close();
        SW.Dispose();
        playerItem.data.Clear();
    }
}

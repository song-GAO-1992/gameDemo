using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 读取Json文件，将信息存储进PlayerPrefs
/// </summary>
public class ReadJsonCommand : EventCommand
{
    //[Inject]
    //public PlayerData playerData { get; set; }
    PlayerItem playerItem = new PlayerItem();
    public override void Execute()
    {
        //获取当前场景信息
        Scene scene = SceneManager.GetActiveScene();
        //获取Json配置信息
        ReadJson(ref playerItem);
        //playerData信息的存储
        //PlayerItemToPlayerData(playerItem,playerData);
        //playerPrefs信息的存储
        //SetUpPlayerPrefs(playerData);
        SetUpPlayerPrefs(playerItem);
        SceneManager.LoadScene(scene.buildIndex + 1);

    }

    public override void Fail()
    {
        Debug.LogWarning(" in ReadJsonCommand: Json信息读取失败！！！");
    }

    //读取Json信息
    PlayerItem ReadJson(ref PlayerItem playerItem)
    {
        TextAsset TA = Resources.Load("Json/PlayerData", typeof(TextAsset)) as TextAsset;
        return playerItem = JsonUtility.FromJson<PlayerItem>(TA.text);
    }

    #region Useless
    ////将PlayerItem中的数据存储进PlayerData
    //void PlayerItemToPlayerData(PlayerItem playerItem, PlayerData playerData)
    //{
    //    playerData.HP = playerItem.data[0].Hp;
    //    playerData.Score = playerItem.data[0].Score;
    //    playerData.Level = playerItem.data[0].Level;
    //    playerData.IsHelmetArmed = playerItem.data[0].IsHelmetArmed;
    //}

    ////使用PlayerPrefs存储信息
    //void SetUpPlayerPrefs(PlayerData playerData)
    //{
    //    PlayerPrefs.SetInt("Hp", playerData.HP);
    //    PlayerPrefs.SetInt("Score", playerData.Score);
    //    PlayerPrefs.SetInt("Level", playerData.Level);
    //    PlayerPrefs.SetString("IsHelmetArmed", playerData.IsHelmetArmed.ToString());
    //}
    #endregion

    //使用PlayerPrefs存储信息
    void SetUpPlayerPrefs(PlayerItem playerItem)
    {
        PlayerPrefs.SetInt("Hp", playerItem.data[0].Hp);
        PlayerPrefs.SetInt("Score", playerItem.data[0].Score);
        PlayerPrefs.SetInt("Level", playerItem.data[0].Level);
        PlayerPrefs.SetString("IsHelmetArmed", playerItem.data[0].IsHelmetArmed.ToString());
    }
}








[Serializable]
public class PlayerItem
{
    public List<Player> data;
    public PlayerItem()
    {
        data = new List<Player>();
    }
}



[Serializable]
public class Player
{
    public int Hp;
    public int Score;
    public int Level;
    public bool IsHelmetArmed;
}
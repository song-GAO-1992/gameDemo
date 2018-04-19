using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : View
{

    //玩家信息
    [SerializeField]
    private int level;
    [SerializeField]
    private bool isHelmetArmed;

    //玩家等级显示
    Text text;
    string LevelPreFix = "Level: ";

    //头盔
    GameObject helMet;
    SkinnedMeshRenderer helmetMeshRender;

    //受伤粒子特效
    ParticleSystem blood;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    //初始化
    public void Init()
    {
        blood = transform.Find("BloodSprayEffect").GetComponent<ParticleSystem>();
        helMet = transform.Find("kid_from_space_helmet").gameObject;
        helmetMeshRender = helMet.GetComponent<SkinnedMeshRenderer>();
        text = transform.Find("LevelPanel").Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        if (isHelmetArmed == true)
        {
            helmetMeshRender.enabled = true;
        }
    }

    //设置玩家信息
    public void SetUpPlayerBaseInfo(int health, int score, int level, bool isHelmetArmed)
    {
        this.level = level;
        this.isHelmetArmed = isHelmetArmed;
        UpdateEquipment(isHelmetArmed);
        UpdateLevelPanel(level.ToString());
    }

    //更新装备
    public void UpdateEquipment(bool isHelmetArmed)
    {
        if (isHelmetArmed == true)
        {
            isHelmetArmed = true;
            helmetMeshRender.enabled = true;
        }
        else
        {
            helmetMeshRender.enabled = false;
        }
    }

    //碰撞检测
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Equip"))
        {
            collision.collider.gameObject.SetActive(false);
            dispatcher.Dispatch("PickEquip", true);
        }

        if(collision.collider.CompareTag("Trap"))
        {
            dispatcher.Dispatch("Attacked");
        }
       
    }

    //碰撞停留检测
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.CompareTag("ConstTrap"))
        {
            dispatcher.Dispatch("Attacked");
        }
    }

    //更新玩家等级
    public void UpdateLevelPanel(string data)
    {
        text.text = LevelPreFix + data;
    }

    //玩家受伤
    public void PlayerDamaged()
    {
        //播放受伤粒子特效
        blood.Play();
    }
}

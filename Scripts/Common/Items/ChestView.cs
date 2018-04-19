using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : View
{


    Text score;
    BoxCollider boxCollider;
    Animation anim;
    bool isOpened = false;
    int ID;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void Init()
    {
        boxCollider = GetComponent<BoxCollider>();
        score = transform.Find("Canvas").Find("Text").GetComponent<Text>();
        anim = GetComponent<Animation>();
        ID = gameObject.GetHashCode();
    }

    //显示得到的分数
    public void FlashScore(int id, string scoreStr)
    {
        if(id==ID)
        {
            anim.Play();
            score.text = "+" + scoreStr;
            score.CrossFadeColor(new Color(253, 243, 102, 0), 1, true, true, false);
            isOpened = true;
            dispatcher.Dispatch("AddScore",scoreStr);
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && isOpened == false)
        {
            dispatcher.Dispatch("OpenChest",ID);

        }
    }
}

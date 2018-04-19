using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePointView : View
{


    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    BoxCollider boxCollider;


    public void Init()
    {
        boxCollider = GetComponent<BoxCollider>();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            dispatcher.Dispatch("EnterSavePoint");
        }
    }


}

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistPanelMediator : EventMediator
{

    [Inject]
    public RegistPanelView registPanelView { get; set; }

    public override void OnRegister()
    {
        registPanelView.dispatcher.AddListener("RegistClicked",OnRegisterClicked);
    }



    void OnRegisterClicked(IEvent iev)
    {
        dispatcher.Dispatch(UIEvents.RegisterClick,iev.data);
    }







}

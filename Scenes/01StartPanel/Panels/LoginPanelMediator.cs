using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanelMediator : EventMediator
{
    [Inject]
    public LoginPanelView loginPanelView { get; set; }
    public override void OnRegister()
    {
        loginPanelView.dispatcher.AddListener("LoginClicked", OnLoginClicked);
    }


    void OnLoginClicked(IEvent iev)
    {
        dispatcher.Dispatch(UIEvents.LoginClick,iev.data);
    }
}

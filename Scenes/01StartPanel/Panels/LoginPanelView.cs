using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void OnLoginClick(string data)
    {
        dispatcher.Dispatch("LoginClicked",data);
    }



}

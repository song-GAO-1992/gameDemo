using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistPanelView : View {

	[Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void OnRegistClicked(string data)
    {
        dispatcher.Dispatch("RegistClicked",data);
    }
}

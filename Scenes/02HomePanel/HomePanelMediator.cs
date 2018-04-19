using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanelMediator : EventMediator
{
    [Inject]
    public HomePanelView homePanelView { get; set; }

    public override void OnRegister()
    {
        homePanelView.Init();
        homePanelView.dispatcher.AddListener("LoadGame", OnLoadGameClicked);
        homePanelView.dispatcher.AddListener("SaveGame", OnSaveGameClicked);
        homePanelView.dispatcher.AddListener("SetUp", OnSettingsClicked);
        homePanelView.dispatcher.AddListener("ExitGame", OnExitClicked);
    }

    void OnLoadGameClicked()
    {
        dispatcher.Dispatch(GameEvent.LoadGame);
    }

    void OnSaveGameClicked()
    {
        dispatcher.Dispatch(GameEvent.SaveGame);
        //dispatcher.Dispatch(GameEvent.SaveJson);
    }

    void OnSettingsClicked()
    {
        dispatcher.Dispatch(GameEvent.Settings);
    }

    void OnExitClicked()
    {
        dispatcher.Dispatch(GameEvent.ExitGame);
    }



}

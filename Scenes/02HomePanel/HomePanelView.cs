using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanelView : View {

    Button loadGame_BT;
    Button saveGame_BT;
    Button settings_BT;
    Button exit_BT;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }


    public void Init()
    {
        loadGame_BT = transform.Find("LoadGame_BT").GetComponent<Button>();
        loadGame_BT.onClick.AddListener(OnLoadGameClicked);
        saveGame_BT = transform.Find("SaveGame_BT").GetComponent<Button>();
        saveGame_BT.onClick.AddListener(OnSaveGameClicked);
        settings_BT = transform.Find("Settings_BT").GetComponent<Button>();
        settings_BT.onClick.AddListener(OnSettingsClicked);
        exit_BT = transform.Find("Exit_BT").GetComponent<Button>();
        exit_BT.onClick.AddListener(OnExitClicked);
    }


    void OnLoadGameClicked()
    {
        dispatcher.Dispatch("LoadGame");
    }

    void OnSaveGameClicked()
    {
        dispatcher.Dispatch("SaveGame");
    }

    void OnSettingsClicked()
    {
        dispatcher.Dispatch("SetUp");
    }

    void OnExitClicked()
    {
        dispatcher.Dispatch("ExitGame");
    }
}




using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePointMediator : EventMediator
{
    [Inject]
    public SavePointView savePointView { get; set; }
    public override void OnRegister()
    {
        savePointView.dispatcher.AddListener("EnterSavePoint", OnEnterSavePoint);
    }

    void OnEnterSavePoint()
    {
        dispatcher.Dispatch(GameEvent.EnterSavePoint);
    }


    
   



}

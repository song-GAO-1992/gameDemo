using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ScoreItemCommand : EventCommand
{

    [Inject]
    public PlayerData playerData { get; set; }
    StringBuilder dataSB= new StringBuilder();
    public override void Execute()
    {
        int score = Random.Range(10, 30);
        dataSB.AppendFormat("{0}+{1}",evt.data.ToString(),score);
        dispatcher.Dispatch(PlayerEventsList_C.ScoreBack, dataSB.ToString());
    }






}

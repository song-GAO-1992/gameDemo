using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreCommand : EventCommand {

    [Inject]
    public PlayerData playerData { get; set; }
    public override void Execute()
    {
        int score;
        int.TryParse(evt.data.ToString(),out score);
        playerData.Score += score;
        dispatcher.Dispatch(PlayerEventsList_V.UpdateInfo);
    }
}

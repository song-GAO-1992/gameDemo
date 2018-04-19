using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameEvent : EventCommand {

    public override void Execute()
    {
        dispatcher.Dispatch(GameEvent.SaveJson);
    }
}

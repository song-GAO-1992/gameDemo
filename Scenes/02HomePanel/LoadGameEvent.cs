using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameEvent : EventCommand {

    public override void Execute()
    {
        dispatcher.Dispatch(GameEvent.ReadJson);
    }
}

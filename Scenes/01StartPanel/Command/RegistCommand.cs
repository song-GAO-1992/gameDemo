using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistCommand : EventCommand {

    public override void Execute()
    {
        Debug.Log("Command works");
        Debug.Log(evt.data);
    }
}

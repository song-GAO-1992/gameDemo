using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeCommand : EventCommand
{

    public override void Execute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

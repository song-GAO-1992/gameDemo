﻿using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameCommand : EventCommand {

    public override void Execute()
    {
        Application.Quit();
    }
}

using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//界面开始，读取Json文件
public class HomeStartCommand : EventCommand {

    public override void Execute()
    {
        Debug.Log("HomePanel Start");
    }
}

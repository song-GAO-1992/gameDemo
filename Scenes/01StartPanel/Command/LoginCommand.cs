using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginCommand : EventCommand
{

    public override void Execute()
    {
        string[] data = evt.data.ToString().Split('-');
        //进行验证
        if (data[0] == "123" && data[1] == "123")
        {
            //验证成功
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
}

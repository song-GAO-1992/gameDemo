using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UIManager.Instance.PushPanel(PanelType.Welcome);
    }

    private void OnDestroy()
    {
        //UIManager.Instance.PanelStack = null;
        //UIManager.Instance.PanelList = null;
        //UIManager.Instance.PanelPathDict = null;
        //UIManager.Instance.PanelTypeByEnum = null;

        //while (UIManager.Instance.PanelStack.Count > 0)
        //{
        //    UIManager.Instance.PopPanel();
        //}

    }


}

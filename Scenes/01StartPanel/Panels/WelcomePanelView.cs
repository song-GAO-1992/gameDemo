using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WelcomePanelView : View
{


    Button welcome_BT;

    public void Init()
    {
        welcome_BT = GetComponent<Button>();
        welcome_BT.onClick.AddListener(OnWelcomeClicked);
    }

    void OnWelcomeClicked()
    {
        
    }

}

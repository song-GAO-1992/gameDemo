using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomePanel : BasePanel
{

    Button Login_BT;
    CanvasGroup canvasGroup;



    public override void OnInit()
    {
        if(!isPushedOnce)
        {
            Login_BT = GetComponent<Button>();
            Login_BT.onClick.AddListener(OnLoginClicked);
            canvasGroup = GetComponent<CanvasGroup>();
            isPushedOnce = true;
        }
       
    }

    void OnLoginClicked()
    {
        UIManager.Instance.PushPanel(PanelType.Login);
    }

    public override void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public override void OnPause()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    public override void OnResume()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public override void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

}

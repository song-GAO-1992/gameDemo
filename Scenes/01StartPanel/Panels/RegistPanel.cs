using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistPanel : BasePanel
{

    CanvasGroup canvasGroup;
    Button regist_BT;
    Button quit_BT;
    InputField name_IF;
    InputField password_IF;
    InputField rePassword_IF;

    Text message;
    CanvasGroup message_CG;
    float targetAlpha;

    RegistPanelView registPanelView;

    public override void OnInit()
    {
        if (!isPushedOnce)
        {
            regist_BT = transform.Find("LogIn_BT").GetComponent<Button>();
            regist_BT.onClick.AddListener(OnRegistClicked);
            quit_BT = transform.Find("RegistQuit_BT").GetComponent<Button>();
            quit_BT.onClick.AddListener(OnQuitClicked);
            name_IF = transform.Find("Name_IF").GetComponent<InputField>();
            password_IF = transform.Find("PSW_IF").GetComponent<InputField>();
            rePassword_IF = transform.Find("REPSW_IF").GetComponent<InputField>();

            message = transform.Find("Message").GetComponent<Text>();

            message = transform.Find("Message").GetComponent<Text>();
            message_CG = transform.Find("Message").GetComponent<CanvasGroup>();
            targetAlpha = 0;
            canvasGroup = GetComponent<CanvasGroup>();
            registPanelView = GetComponent<RegistPanelView>();
            isPushedOnce = true;
        }

    }


    private void Update()
    {
        if (Mathf.Abs(message_CG.alpha - targetAlpha) > 0.01f)
        {
            message_CG.alpha = Mathf.Lerp(message_CG.alpha, targetAlpha, 0.1f);
        }
        else
        {
            targetAlpha = 0;
        }
    }


    void OnRegistClicked()
    {

        if (name_IF.text == "")
        {
            ShowMessage("账号不能为空！");
            return;
        }
        if ( password_IF.text == "" )
        {
            ShowMessage("密码不能为空！");
            return;
        }
        if (rePassword_IF.text == "")
        {
            ShowMessage("重复密码不能为空！");
            return;
        }

        if(password_IF.text!=rePassword_IF.text)
        {
            ShowMessage("密码,重复密码不一致！");
            return;
        }

        string data = name_IF.text + "-" + password_IF.text;

        registPanelView.OnRegistClicked(data);
    }




    void OnQuitClicked()
    {
        UIManager.Instance.PopPanel();
    }

    public override void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnResume()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnPause()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }




    public void ShowMessage(string str)
    {

        message.text = str;
        targetAlpha = 1;
    }



}

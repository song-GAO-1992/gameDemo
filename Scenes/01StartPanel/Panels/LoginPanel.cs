using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    Button Login_BT;
    Button Regist_BT;
    Button Quit_BT;


    InputField name_IF;
    InputField password_IF;

    Text message;
    CanvasGroup message_CG;
    float targetAlpha;

    CanvasGroup canvasGroup;


    LoginPanelView loginPanelView;

    public override void OnInit()
    {
        if (!isPushedOnce)
        {
            Login_BT = transform.Find("LogIn_BT").GetComponent<Button>();
            Login_BT.onClick.AddListener(OnLoginClicked);
            Regist_BT = transform.Find("Regist_BT").GetComponent<Button>();
            Regist_BT.onClick.AddListener(OnRegistClicked);
            Quit_BT = transform.Find("LogInQuit_BT").GetComponent<Button>();
            Quit_BT.onClick.AddListener(OnQuitClicked);

            name_IF = transform.Find("Name_IF").GetComponent<InputField>();
            password_IF = transform.Find("PSW_IF").GetComponent<InputField>();

            message = transform.Find("Message").GetComponent<Text>();
            message_CG = transform.Find("Message").GetComponent<CanvasGroup>();


            canvasGroup = GetComponent<CanvasGroup>();
            isPushedOnce = true;
            targetAlpha = 0;
            //获取LoginPanelView组件
            loginPanelView = GetComponent<LoginPanelView>();
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


    void OnLoginClicked()
    {

        if (name_IF.text == "" && password_IF.text != "")
        {
            ShowMessage("账号不能为空");
            return;
        }
        else if (name_IF.text != "" && password_IF.text == "")
        {
            ShowMessage("密码不能为空");
            return;
        }
        else if(name_IF.text == "" && password_IF.text == "")
        {
            ShowMessage("账号，密码不能为空");
            return;
        }

        string data = name_IF.text + "-" + password_IF.text;


        //调取LoginPanelView的登陆函数
        loginPanelView.OnLoginClick(data);
    }



    void OnRegistClicked()
    {
        UIManager.Instance.PushPanel(PanelType.Regist);
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

    public void ShowMessage(string str)
    {
       
        message.text = str;
        targetAlpha = 1;
    }
}

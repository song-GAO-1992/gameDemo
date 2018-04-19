using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfoView : View
{


    Text health_t;
    Text score_t;
    Text death_t;



    Button restart;
    Button quit;
    Button nextScene;
    Button saveFile;
    Button closeRestartPanel;
    Button closeSavePanel;
    Button homeIcon;
    Button home;
    Button quitHomePanel;




    int score = 0;
    int health = 100;
    float targetAlpha;
    CanvasGroup restartPanel;
    [SerializeField]
    CanvasGroup damagePanel;
    CanvasGroup nextScenePanel;
    CanvasGroup homePanel;


    string health_Pre = "Health: ";
    string score_Pre = "Score: ";


    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    /// <summary>
    /// 初始化所有组件
    /// </summary>
    public void Init()
    {
        restartPanel = transform.Find("Restart").GetComponent<CanvasGroup>();
        damagePanel = transform.Find("Damage").GetComponent<CanvasGroup>();
        nextScenePanel = transform.Find("NextScene").GetComponent<CanvasGroup>();




        health_t = transform.Find("Health").GetComponent<Text>();
        score_t = transform.Find("Score").GetComponent<Text>();
        death_t = transform.Find("Restart").Find("Death").GetComponent<Text>();


        restart = transform.Find("Restart").Find("Restart").GetComponent<Button>();
        restart.onClick.AddListener(OnRestart);
        quit = transform.Find("Restart").Find("Quit").GetComponent<Button>();
        quit.onClick.AddListener(OnQuit);
        closeRestartPanel = transform.Find("Restart").Find("Close").GetComponent<Button>();
        closeRestartPanel.onClick.AddListener(OnCloseButtonClicked);

        nextScene = transform.Find("NextScene").Find("NextSceneButton").GetComponent<Button>();
        nextScene.onClick.AddListener(OnNextSceneClick);
        saveFile= transform.Find("NextScene").Find("SaveFile").GetComponent<Button>();
        saveFile.onClick.AddListener(OnSaveButtonClicked);

       
        closeSavePanel = transform.Find("NextScene").Find("Close").GetComponent<Button>();
        closeSavePanel.onClick.AddListener(OnCloseSaveButtonClicked);
        

        homeIcon = transform.Find("Home_BT").GetComponent<Button>();
        homeIcon.onClick.AddListener(OnHomeIconClicked);
        home = transform.Find("Home").Find("ReturnHome").GetComponent<Button>();
        home.onClick.AddListener(OnReturnHomeClicked);
        homePanel = transform.Find("Home").GetComponent<CanvasGroup>();
        quitHomePanel=transform.Find("Home").Find("Close").GetComponent<Button>();
        quitHomePanel.onClick.AddListener(OnQuitHomeClicked);
        targetAlpha = 0;
    }


    private void Update()
    {

        if (Mathf.Abs(targetAlpha- damagePanel.alpha ) > 0.01f)
        {
            damagePanel.alpha = Mathf.Lerp(damagePanel.alpha, targetAlpha, 0.3f);
        }
        else
        {
            targetAlpha = 0;
        }

    }


    //更新HP
    public void UpdatePlayerInfo_HP(int health)
    {
        health_t.text = health_Pre + health;
    }
    //更新Score
    public void UpdatePlayerInfo_Score(int score)
    {
        score_t.text = score_Pre + score;
    }
    //更新HP和Score
    public void UpdatePlayerInfo(int health, int score)
    {
        health_t.text = health_Pre + health;
        score_t.text = score_Pre + score;
    }



    public void FlashDamagePanel()
    {
        targetAlpha = 1;
    }



    void OnSaveButtonClicked()
    {
        dispatcher.Dispatch("SaveFileClicked");
    }

    void OnNextSceneClick()
    {
        dispatcher.Dispatch("MoveNextScene");
    }



    public void ShowReStartPanel()
    {
        restartPanel.alpha = 1;
        restartPanel.blocksRaycasts = true;
    }

    public void ShowSaveFilePanel()
    {
        nextScenePanel.alpha = 1;
        nextScenePanel.blocksRaycasts = true;
    }





    public void PlayerDeath()
    {
        restartPanel.alpha = 1;
        restartPanel.blocksRaycasts = true;
        death_t.text = "You are dead!";
    }



    void OnCloseButtonClicked()
    {
        restartPanel.alpha = 0;
        restartPanel.blocksRaycasts = false;
        death_t.text = "";
    }


    void OnCloseSaveButtonClicked()
    {
        nextScenePanel.alpha = 0;
        nextScenePanel.blocksRaycasts = false;
    }


    /// <summary>
    /// 退出
    /// </summary>
    private void OnQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 重新启动
    /// </summary>
    private void OnRestart()
    {
        SceneManager.LoadScene(1);
    }



    void OnHomeIconClicked()
    {
        homePanel.alpha = 1;
        homePanel.blocksRaycasts = true;
    }

    void OnReturnHomeClicked()
    {
        homePanel.alpha = 0;
        homePanel.blocksRaycasts = false;
        dispatcher.Dispatch("ReturnHomeClicked");
        SceneManager.LoadScene(1);
        
    }



    void OnQuitHomeClicked()
    {
        homePanel.alpha = 0;
        homePanel.blocksRaycasts = false;
    }

}

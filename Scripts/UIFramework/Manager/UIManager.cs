using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    #region 单例模式
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }
    #endregion

    // 构造函数(私有)
    private UIManager()
    {
        JsonToObject();
        DictAddItem();
    }

    //Json生成对象接收方
    public UIPanelInfo PanelList;
    private Transform _canvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (_canvasTransform == null)
            {
                _canvasTransform = GameObject.Find("StartPanel").transform;
            }
            return _canvasTransform;
        }
    }

    /// Json文件转对象
    private void JsonToObject()
    {
        TextAsset TA = Resources.Load<TextAsset>("Json/PanelInfo");
        PanelList = JsonUtility.FromJson<UIPanelInfo>(TA.text);
    }



    public Dictionary<PanelType, string> PanelPathDict;
    public Dictionary<PanelType, BasePanel> PanelTypeByEnum;
    public Stack<BasePanel> PanelStack;

    public void PushPanel(PanelType panelType)
    {
        if (PanelStack == null)
        {
            PanelStack = new Stack<BasePanel>();
        }

        if (PanelStack.Count > 0)
        {
            BasePanel topPanel = PanelStack.Peek();
            topPanel.OnPause();
        }
        BasePanel panelToPush = GetPanel(panelType);
        panelToPush.OnInit();
        panelToPush.OnEnter();
        PanelStack.Push(panelToPush);

    }


    public void PopPanel()
    {
        if (PanelStack == null)
        {
            PanelStack = new Stack<BasePanel>();
        }
        if (PanelStack.Count <= 0) return;
        BasePanel topPanel = PanelStack.Pop();
        topPanel.OnExit();
        if (PanelStack.Count <= 0) return;
        BasePanel topPanel2 = PanelStack.Peek();
        topPanel2.OnResume();
    }


    public BasePanel GetPanel(PanelType panelType)
    {
        if (PanelTypeByEnum == null)
        {
            PanelTypeByEnum = new Dictionary<PanelType, BasePanel>();
        }
        BasePanel panel = PanelTypeByEnum.TryGet(panelType);
        if (panel == null)
        {

            string path = PanelPathDict.TryGet(panelType);
            string pathstr = PanelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(pathstr)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            PanelTypeByEnum.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }



    }



    // 给存储路径的字典添加选项
    public void DictAddItem()
    {
        if (PanelPathDict == null) PanelPathDict = new Dictionary<PanelType, string>();
        for (int i = 0; i < PanelList.InfoList.Length; i++)
        {
            string PanelPathStr;
            PanelPathStr = PanelList.InfoList[i].PanelPath;
            PanelPathDict.Add(PanelList.InfoList[i].PanelTypeEnum, PanelPathStr);
        }
    }

}

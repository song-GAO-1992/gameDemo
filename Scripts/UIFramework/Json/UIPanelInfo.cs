using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UIPanelInfo
{

    public Data[] InfoList;
}

[Serializable]
public class Data
{

    public string PanelType;
    public string PanelPath;

    private PanelType _panelType;
    public PanelType PanelTypeEnum
    {
        get
        {
            PanelType Type = (PanelType)System.Enum.Parse(typeof(PanelType), PanelType);
            _panelType = Type;
            return _panelType;
        }
    }

    /// <summary>
    /// 重写ToString()方法
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string s = null;
        s += "PanelType: ";
        s += PanelType;
        s += " PanelPath: ";
        s += PanelPath;
        s += " Enum: ";
        s += PanelTypeEnum;
        return s;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{

    protected bool isPushedOnce = false;

    public virtual void OnInit()
    {

    }

    /// <summary>
    /// 进入该Panel
    /// </summary>
	public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 移出该Panel
    /// </summary>
    public virtual void OnExit()
    {

    }

    /// <summary>
    ///  暂停该panel
    /// </summary>
    public virtual void OnPause()
    {

    }


    /// <summary>
    /// 恢复该panel
    /// </summary>
    public virtual void OnResume()
    {

    }





}

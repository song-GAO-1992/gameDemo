using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 负责子弹的初始化，添加进资源池中
/// 可用子弹的检索
/// 子弹的发射
/// </summary>
public class PoolManager : MonoBehaviour {

    [SerializeField]
    private Transform firePos;
    Bullet[] bullets = new Bullet[60];

	// 资源池初始化
	void Start () {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Resources.Load<GameObject>("Bullet").GetComponent<Bullet>();
            bullets[i].Init();
        }

	}
	
    void Update()
    {
        
    }

    /// <summary>
    /// 获取子弹，如果有子弹，则返回true
    /// 如果子弹不足，返回false
    /// </summary>
    /// <returns></returns>
    public bool GetBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if(bullets[i].CheckState())
            {
                //TODO 传递位置和方向
                //bullets[i].Fire(firePos,);
                return true;
            }
        }
        return false;
    }

}

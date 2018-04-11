using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    bool isFiring = false;
    MeshRenderer renderer;
    Vector3 direction;
    public bool isAvilable;

    //用于资源池初始化
    public void Init()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        isAvilable = true;
    }


    private void FixedUpdate()
    {
        if (!isAvilable)
        {
            transform.Translate(direction*speed,Space.World);
        }

    }


    /// <summary>
    /// 子弹的碰撞检测
    /// 销毁自身
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        DestroySelf();
    }


    /// <summary>
    /// 子弹可用设置
    /// </summary>
    public void EnableBullet()
    {
        isAvilable = true;
    }

    /// <summary>
    /// 子弹不可用设置
    /// </summary>
    public void DisableBullet()
    {
        isAvilable = false;
    }


    /// <summary>
    /// 发射位置的设置
    /// 子弹飞行中设置
    /// 子弹可见的设置
    /// 子弹设置为不可用
    /// </summary>
    /// <param name="firePos"></param>
    /// <param name="dirPos"></param>
    public void Fire(Vector3 firePos, Vector3 dirPos)
    {
        isFiring = true;
        SetPosition(firePos, dirPos);
        renderer.enabled = true;
        DisableBullet();
    }

    /// <summary>
    /// 销毁自身，自身不可见
    /// 子弹设置为可用
    /// </summary>
    private void DestroySelf()
    {
        renderer.enabled = false;
        transform.position = Vector3.zero;
        EnableBullet();
    }


    //设置射击时的位置和角度
    private void SetPosition(Vector3 firePos, Vector3 dirPos)
    {
        transform.position = firePos;
        direction = dirPos;
    }

    public bool CheckState()
    {
        return isAvilable;
    }


}

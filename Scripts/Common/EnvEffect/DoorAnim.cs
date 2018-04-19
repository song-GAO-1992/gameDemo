using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAnim : MonoBehaviour
{

    Animation anim;
    CapsuleCollider collider;

    void Start()
    {
        anim = GetComponent<Animation>();
        collider = GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("DoorRotate");
        }
    }



}

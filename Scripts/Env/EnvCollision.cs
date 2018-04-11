using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvCollision : MonoBehaviour {


    Vector3 original;
    Animator anim;
    CapsuleCollider capsuleCollider;
    private void Start()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if(!anim.GetBool("OnGround"))
        {
            capsuleCollider.enabled = false;
            //capsuleCollider.height *= 0.5f;
        }
        else
        {
            //capsuleCollider.height *= 2f;
            capsuleCollider.enabled = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag=="Env")
        {

        }
    }
}

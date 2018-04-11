using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAnim : MonoBehaviour {

    Animation anim;
    CapsuleCollider collider;

	void Start () {
        anim = GetComponent<Animation>();
        collider = GetComponent<CapsuleCollider>();
        
    }
	

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            anim.Play("DoorRotate");

        }
    }


}

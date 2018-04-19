using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : MonoBehaviour {


    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag=="Player")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    private void OnDestroy()
    {
        GameObject.Destroy(this);
    }
}

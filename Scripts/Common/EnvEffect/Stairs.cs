using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {


    Collider collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player"&&Input.GetKeyDown(KeyCode.W))
        {
            collision.transform.position += new Vector3(0, 2f, 0);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    protected Collider collider;

    private void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        collider = GetComponent<Collider>();
    }

    void Update () {
		
	}

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }


}

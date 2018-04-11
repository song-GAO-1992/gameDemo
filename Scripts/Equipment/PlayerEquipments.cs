using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipments : MonoBehaviour {


    GameObject HelMet;

	void Start () {
        HelMet = transform.Find("kid_from_space_helmet").gameObject;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name== "kid_from_space_helmet")
        {
            HelMet.SetActive(true);
        }
        if (collision.collider.name == "Gun")
        {
            //TODO
            //HelMet.SetActive(true);
        }
    }
}

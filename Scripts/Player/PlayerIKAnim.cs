using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIKAnim : MonoBehaviour {

    [SerializeField]
    Transform left;
    [SerializeField]
    Transform right;

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPosition(AvatarIKGoal.LeftHand, left.position);
        animator.SetIKPosition(AvatarIKGoal.RightHand, right.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour {

    public Vector3 targetRotation;
    Transform t;
	// Use this for initialization
	void Start () {
        t = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        t.eulerAngles = targetRotation;//for now need to add follow parent y and z rotation. Or use a second script placed on the parent
	}
}

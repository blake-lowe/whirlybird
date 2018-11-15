using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour {//finished

    Transform t;
	// Use this for initialization
	void Start () {
        t = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetRotation = new Vector3(GetComponentInParent<Transform>().eulerAngles.x, GetComponentInParent<Transform>().eulerAngles.y, 0);
        t.eulerAngles = targetRotation;
	}
}

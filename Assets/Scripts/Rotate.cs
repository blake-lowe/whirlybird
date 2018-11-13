using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public GameObject rotor;
    public float rotationSpeed;

    private Transform t;
    // Use this for initialization
    void Start () {
        t = rotor.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currentPosition = t.localEulerAngles;
        t.localEulerAngles = new Vector3(0, currentPosition.y + rotationSpeed * Time.deltaTime, 0);
    }
}

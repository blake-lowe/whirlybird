using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PivotController : MonoBehaviour {//unfinished

    public Rigidbody HingeY;
    public float YTorqueFactor;
    public Rigidbody HingeZ;
    public float ZTorqueFactor;
    public Transform Chopper;
    public float ChopperRotationLimit;//in one direction
    public Text PitchLabel;
    public Text ThrustLabel;
	// Use this for initialization
	void Start () {
		//todo
	}
	
	// Update is called once per frame
	void Update () {
        //assign axis values to ui elements//
        if (PitchLabel != null)
        {
            PitchLabel.text = Input.GetAxis("Pitch").ToString();
        }
        else
        {
            Debug.Log("Pitch Label not assigned to PivotController.");
        }
        if (ThrustLabel != null)
        {
            ThrustLabel.text = Input.GetAxis("Thrust").ToString();
        }
        else
        {
            Debug.Log("Thrust Label not assigned to PivotController.");
        }
    }
}

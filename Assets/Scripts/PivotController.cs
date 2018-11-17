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
    public bool UIEnabled;
    public GameObject Canvas;
    public Text PitchValue;
    public Text ThrustValue;

	// Use this for initialization
	void Start () {
        Canvas.SetActive(UIEnabled);
	}
	
	// Update is called once per frame
	void Update () {
        //assign axis values to ui elements//
        if (PitchValue != null)
        {
            PitchValue.text = Input.GetAxis("Pitch").ToString();
        }
        else
        {
            Debug.Log("Pitch Label not assigned to PivotController.");
        }
        if (ThrustValue != null)
        {
            ThrustValue.text = Input.GetAxis("Thrust").ToString();
        }
        else
        {
            Debug.Log("Thrust Label not assigned to PivotController.");
        }
        //change chopper rotation
        Chopper.localEulerAngles = new Vector3(-1* Input.GetAxis("Pitch") * ChopperRotationLimit, Chopper.localEulerAngles.y, Chopper.localEulerAngles.z);
        //determine y and z torque
        float theta = (float)(Input.GetAxis("Pitch")*ChopperRotationLimit*Mathf.PI/180.0);
        float zTorque = Input.GetAxis("Thrust")*ZTorqueFactor*Mathf.Cos(theta);
        float yTorque = Input.GetAxis("Thrust")*YTorqueFactor*Mathf.Sin(theta);
        Debug.Log(yTorque + "  " + zTorque);
        HingeY.AddTorque(new Vector3(0, yTorque, 0), ForceMode.Acceleration);
        HingeZ.AddTorque(new Vector3(0, 0, zTorque), ForceMode.Acceleration);



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PivotController : MonoBehaviour {//unfinished

    public bool ControlsEnabled;
    public Rigidbody HingeY;
    public float YTorqueFactor;
    public Rigidbody HingeZ;
    public float ZTorqueFactor;
    public Transform Chopper;
    public float ChopperRotationLimit;//in one direction
    //public bool UIEnabled;
    public GameObject Canvas;
    public Text PitchValue;
    public Text ThrustValue;
    public Rotate RotorScript;
    public float minRotorSpeed;
    public float RotorSpeed;

    public Slider PitchSlider;
    public Slider ThrustSlider;

    private float RecentPitchAxis;

	// Use this for initialization
	void Start () {
        //Canvas.SetActive(UIEnabled);
	}
	
	// Update is called once per frame
	void Update () {
        //set rotor speed
        RotorScript.rotationSpeed = RotorSpeed * Input.GetAxis("Thrust") + minRotorSpeed;
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
        PitchSlider.value = Input.GetAxis("Pitch");
        ThrustSlider.value = Input.GetAxis("Thrust");
        
        //determine y and z torque
        float theta = (float)(-Input.GetAxis("Pitch") * ChopperRotationLimit * Mathf.PI / 180.0);
        float zTorque = Input.GetAxis("Thrust") * ZTorqueFactor * Mathf.Cos(theta);//this torque is being applied in reverse as the system rotates 180 degrees
        float yTorque = Input.GetAxis("Thrust") * YTorqueFactor * Mathf.Sin(theta);

        if (ControlsEnabled)
        {
            RecentPitchAxis = Input.GetAxis("Pitch");
            Chopper.localEulerAngles = new Vector3(RecentPitchAxis * ChopperRotationLimit, Chopper.localEulerAngles.y, Chopper.localEulerAngles.z);
            HingeY.AddRelativeTorque(new Vector3(0, yTorque, 0), ForceMode.Acceleration);
            HingeZ.AddRelativeTorque(new Vector3(0, 0, zTorque), ForceMode.Acceleration);
        }
        else if(!ControlsEnabled)
        {
            Chopper.localEulerAngles = new Vector3(RecentPitchAxis * ChopperRotationLimit, Chopper.localEulerAngles.y, Chopper.localEulerAngles.z);
            RotorScript.rotationSpeed = 0;
        }


    }
}

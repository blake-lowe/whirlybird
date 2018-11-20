using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPadScript : MonoBehaviour {//put this script on the trigger object

    public Material active;
    public Material inactive;
    MeshRenderer mr;
    public bool isActive;
    public bool isTriggered;

	// Use this for initialization
	void Awake () {
        mr = gameObject.GetComponent<MeshRenderer>();
        mr.material = inactive;
        isActive = false;
        isTriggered = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            isTriggered = true;
        }
    }
    public void Activate()
    {
        mr.material = active;
        isActive = true;
    }
    public void Deactivate()
    {
        mr.material = inactive;
        isActive = false;
        isTriggered = false;
    }
}

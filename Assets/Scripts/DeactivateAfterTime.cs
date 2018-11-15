using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour {//finished

    public float deactivateAfterSeconds;
	// Use this for initialization
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(deactivateAfterSeconds);
        gameObject.SetActive(false);
    }
	void Start ()
    {
        StartCoroutine(Wait());
    }
}

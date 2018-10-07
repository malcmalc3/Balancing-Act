using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WedgeMechanics : MonoBehaviour {

    public float speed = .01f;
    public float increment = 1f;

    public GameObject WedgePivot;

	// Use this for initialization
	void OnEnable ()
    {
		StartCoroutine("SpinWedge");
        StartCoroutine("SpeedUp");
    }

    IEnumerator SpinWedge()
    {
        while(true)
        {
            WedgePivot.transform.Rotate(Vector3.up * increment, Space.Self);
            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator SpeedUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(30f);
            speed *= 0.75f;
            increment += 0.5f;
        }
    }
}

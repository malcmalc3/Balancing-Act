using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGravity : MonoBehaviour {

    int numChanges = 2;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine("ChangeGravity");
    }

    IEnumerator ChangeGravity()
    {
        for(int x=0; x<numChanges; x++)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            yield return new WaitForSeconds(5);
        }

        GetComponent<Renderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}

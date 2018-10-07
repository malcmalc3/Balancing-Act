using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

    int numChanges = 2;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine("SlowDownTime");
    }

    IEnumerator SlowDownTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(10);
        for(int x=0; x<5; x++)
        {
            Time.timeScale += 0.1f;
            yield return new WaitForSeconds(0.2f);
        }
        Time.timeScale = 1f;

        GetComponent<Renderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}

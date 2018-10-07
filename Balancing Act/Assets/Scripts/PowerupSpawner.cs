using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

    public GameObject wedge;

    Transform[] children;
    Transform powerup;

    void Start()
    {
        StartCoroutine("SpawnPowerup");
        StartCoroutine("StartWedge");
        children = GetComponentsInChildren<Transform>();
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(10);

        while(true)
        {
            powerup = transform.GetChild(Random.Range(0, transform.childCount));
            powerup.gameObject.SetActive(true);
            powerup.transform.position = new Vector3(Random.Range(-1.00f, 1.00f), 0.3f, Random.Range(-1.00f, 1.00f));
            yield return new WaitForSeconds(30);
            powerup.gameObject.SetActive(false);
        }
    }

    IEnumerator StartWedge()
    {
        yield return new WaitForSeconds(65f);
        wedge.gameObject.SetActive(true);
    }
}

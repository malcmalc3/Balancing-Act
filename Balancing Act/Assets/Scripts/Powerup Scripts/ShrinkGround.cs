using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkGround : MonoBehaviour {

    public GameObject ground;
    int duration = 5;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine("ResizeGround");
    }

    IEnumerator ResizeGround()
    {
        Vector3 beforeScale = ground.transform.localScale;
        Vector3 afterScale = new Vector3(beforeScale.x * 0.8f, beforeScale.y, beforeScale.z * 0.8f);
        float scaleUpTime = 0.5f;
        float scaleDownTime = 3f;
        float percentageComplete = 0f;

        float timeStarted = Time.time;
        while (percentageComplete < 1f)
        {
            percentageComplete = (Time.time - timeStarted) / scaleDownTime;
            ground.transform.localScale = Vector3.Lerp(beforeScale, afterScale, Mathf.Clamp(percentageComplete, 0f, 1f));
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(duration);

        percentageComplete = 0f;
        timeStarted = Time.time;
        while (percentageComplete < 1f)
        {
            percentageComplete = (Time.time - timeStarted) / scaleUpTime;
            ground.transform.localScale = Vector3.Lerp(afterScale, beforeScale, Mathf.Clamp(percentageComplete, 0f, 1f));
            yield return new WaitForFixedUpdate();
        }

        GetComponent<Renderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}

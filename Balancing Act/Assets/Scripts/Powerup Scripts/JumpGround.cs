using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGround : MonoBehaviour {

    public GameObject ground;
    //public MeshCollider groundCollider;
    public Rigidbody ballCollider;
    int duration = 5;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine("Jump");
    }

    IEnumerator Jump()
    {
        Debug.Log(ballCollider.collisionDetectionMode);
        //groundCollider.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        ballCollider.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        Vector3 beforeJump = ground.transform.localPosition;
        Vector3 peakJump = new Vector3(beforeJump.x, beforeJump.y + 2f, beforeJump.z);
        float peakTime = 0.2f;
        float dropTime = 0.1f;
        float percentageComplete = 0f;

        for(int x=0; x<3; x++)
        {
            percentageComplete = 0f;
            float timeStarted = Time.time;
            while (percentageComplete < 1f)
            {
                percentageComplete = (Time.time - timeStarted) / peakTime;
                ground.transform.localPosition = Vector3.Lerp(beforeJump, peakJump, Mathf.Clamp(percentageComplete, 0f, 1f));
                yield return new WaitForFixedUpdate();
            }

            //yield return new WaitForSeconds(duration);

            percentageComplete = 0f;
            timeStarted = Time.time;
            while (percentageComplete < 1f)
            {
                percentageComplete = (Time.time - timeStarted) / dropTime;
                ground.transform.localPosition = Vector3.Lerp(peakJump, beforeJump, Mathf.Clamp(percentageComplete, 0f, 1f));
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(1f);
        }

        ballCollider.collisionDetectionMode = CollisionDetectionMode.Continuous;

        GetComponent<Renderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}

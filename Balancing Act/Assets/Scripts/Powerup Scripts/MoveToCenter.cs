using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour {

    public GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("MoveBall");
    }

    IEnumerator MoveBall()
    {
        Vector3 targetPoint = new Vector3(0, 2, 0); //Point above center of platform to move to
        Vector3 beforeGravity = Physics.gravity; //Saves the gravity acting on the ball before we turn gravity off

        Physics.gravity = new Vector3(0, 0, 0); //Turns off gravity so the ball can be placed

        while (Vector3.Distance(ball.transform.position, targetPoint) > 0.1f)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, targetPoint, Time.deltaTime * 5);
            yield return new WaitForEndOfFrame();
        }
        
        //Zeros out any force acting on the ball so it will stay in place
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //Holds the ball above the center for 2 seconds before turning gravity back on
        yield return new WaitForSeconds(2);
        Physics.gravity = beforeGravity;

        //Makes the object for the powerup visible again but disables the powerup object
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        gameObject.SetActive(false);        
    }
}

using UnityEngine;
using System.Collections;

public class BallGravity : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject platformMeshCollider;
    public GameObject arrow;

    public float jumpForce;
    public bool isFalling = true;
    public float gravityX;
    public float gravityZ;
    float enhancer = 1; //Every 30 seconds will increase the range of possible gravity values

    void Start()
    {
        StartCoroutine("ChangeGravity");
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, 0, 0);
    }

    IEnumerator IncreaseEnhancer()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            enhancer += 0.5f;
        }
    }

    IEnumerator ChangeGravity()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            gravityX += (Random.value * 2 * enhancer) - (1 * enhancer);
            gravityZ += (Random.value * 2 * enhancer) - (1 * enhancer);
            Physics.gravity = new Vector3(gravityX, -10f, gravityZ);
            arrow.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !isFalling)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //rb.velocity = Vector3.up * jumpForce; //Jumping this way will halt the velocity on the x and z axes
        }
        isFalling = true;

        if (rb.transform.position.y <= -1)
        {
            FindObjectOfType<TimerScript>().StopTime();
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //we are on something
        isFalling = false;
    }

    public IEnumerator DetectOnScreen()
    {
        bool onScreen = true;
        Camera camera = Camera.main;

        while(onScreen)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 screenPoint = camera.WorldToViewportPoint(rb.position);
            onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }

        EndGameAnimation();
    }

    public void EndGameAnimation()
    {
        StopCoroutine("ChangeGravity");
        rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x, -5f, 5f), -30, Mathf.Clamp(rb.transform.position.z, -5f, 5f));
        rb.velocity = new Vector3(0, 0, 0);
        Physics.gravity = new Vector3(0, 6f, 0);
        rb.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        
        platformMeshCollider.SetActive(false);
    }
}
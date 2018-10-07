using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMechanics : MonoBehaviour {

	public GameObject arrow;
    public GameObject arrowBox1;
    public GameObject arrowBox2;
    public GameObject arrowRotation;
    public GameObject arrowScale;
    public GameObject ball;

    float direction;
    float magnitude;

    // Use this for initialization
    void OnEnable()
    {
        direction = Mathf.Atan2(Physics.gravity.z, -Physics.gravity.x) * Mathf.Rad2Deg;
        arrowRotation.transform.localRotation = Quaternion.Euler(0, direction, 0);

        magnitude = Mathf.Sqrt(Mathf.Pow(Physics.gravity.x, 2) + Mathf.Pow(Physics.gravity.z, 2));
        arrowScale.transform.localScale = new Vector3(magnitude / 2f, 0.3f, 0.5f);

        //Debug.Log(direction + " " + magnitude + "\n");

        StartCoroutine("ShowArrow");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        arrow.transform.position = ball.transform.position;
        arrowRotation.transform.LookAt(ball.transform);
    }

    IEnumerator ShowArrow()
    {
        LeanTween.alpha(arrowBox1, 0.8f, 1f).setEase(LeanTweenType.easeInCirc);
        LeanTween.alpha(arrowBox2, 0.8f, 1f).setEase(LeanTweenType.easeInCirc);

        yield return new WaitForSeconds(1f);
        arrow.transform.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    private float xScaleSpeed = 0.0002f;
    private float yScaleSpeed = 0.0002f;
    private int count;
    //public GameObject canvas;

    void Start()
    {
        count = 0;

        //transform.localScale = new Vector3(Screen.width/18, Screen.height/14, 1);

        /*
        float canvasX = canvas.GetComponent<Rect>().width;
        float canvasY = canvas.GetComponent<Rect>().height;
        transform.localScale = new Vector3(canvasX / 18, canvasY / 14, 1);
        //*/

        //*
        Vector3 v3ViewPort = new Vector3(0, 0, 18);
        Vector3 v3BottomLeft = Camera.main.ViewportToWorldPoint(v3ViewPort);
        v3ViewPort.Set(1, 1, 14);
        Vector3 v3TopRight = Camera.main.ViewportToWorldPoint(v3ViewPort);

        float scaleX = Mathf.Abs(v3BottomLeft.x - v3TopRight.x);
        float scaleY = Mathf.Abs(v3BottomLeft.y - v3TopRight.y);
        //*/

        /*
        float height = 2.0f * Mathf.Abs(Mathf.Tan(0.5f * Camera.main.fieldOfView)) * transform.position.z;
        float width = height* Screen.width / Screen.height;

        Debug.Log(height + " " + width + " " + Camera.main.fieldOfView);
        //*/
        //transform.localScale = new Vector3(scaleX, scaleY, 1);
    }

    void Update()
    {
        transform.localScale += new Vector3(xScaleSpeed, yScaleSpeed, 0);
        count = count + 1;
        if (count == 1000)
        {
            count = 0;
            xScaleSpeed = xScaleSpeed * -1;
            yScaleSpeed = yScaleSpeed * -1;
        }
    }
}

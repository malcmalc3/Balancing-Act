using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class TimerScript : MonoBehaviour
{
    private float startTime;

    public string textTime;
    public bool stop = false;
    public float endTime;

    private float guiTime; //Difference between the actual time and the start time.
    private int minutes;
    private int seconds;
    private int fraction;

    private Text textField; //Create a reference for the textfield
                               //First define two variables. One private and one public variable. Set the first variable to be a float.
                               //Use for textTime a string.

    void Start()
    {
        startTime = Time.time;
        textField = GetComponent<Text>();
        StartCoroutine("CountdownColor");
    }

    IEnumerator CountdownColor()
    {
        textField.color = Color.yellow;
        yield return new WaitForSeconds(5);
        textField.color = Color.white;
    }

    void Update()
    {
        if (!stop)
        {
            guiTime = Mathf.Abs( 5f - (Time.time - startTime) );
            minutes = (int)guiTime / 60; //Divide the guiTime by sixty to get the minutes.
            seconds = (int)guiTime % 60;//Use the euclidean division for the seconds.
            fraction = (int)(guiTime * 100) % 100;

            textTime = string.Format("{0:00}.{1:00}.{2:00}", minutes, seconds, fraction);
            textField.text = textTime; //textTime is the time that will be displayed.
        }
    }

    public void StopTime()
    {
        stop = true;
        endTime = guiTime;
    }
}
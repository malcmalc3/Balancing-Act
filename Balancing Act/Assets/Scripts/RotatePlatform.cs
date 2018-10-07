using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed; //how fast the object should rotate

    public float oldRange = 1;
    public float newRange = 90;
    public float newValue;
    public float mouseX;
    public float mouseY;
    public float rotationX;
    public float rotationZ;

    public static int rotationStyle = 0; //0 for using mouse, 1 for phone rotation

    private void Start()
    {
        chooseRotationStyle();
        if (rotationStyle == 1)
        {
            Debug.Log("You are playing on a phone");
            if(SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }            
    }

    void FixedUpdate()
    {
        //*
        int boxSize = Mathf.Min(Screen.width, Screen.height);

        if(rotationStyle == 0)
        {
            mouseX = Mathf.Clamp(Input.mousePosition.x, (Screen.width / 2) - boxSize / 2, (Screen.width / 2) + boxSize / 2); //Limits mouse position to a square on the game screen
            mouseY = Mathf.Clamp(Input.mousePosition.y, (Screen.height / 2) - boxSize / 2, (Screen.height / 2) + boxSize / 2); //Limits mouse position to a square on the game screen
        }
        else if(rotationStyle == 1)
        {
            mouseX = Mathf.Clamp(Input.gyro.attitude.x, (Screen.width / 2) - boxSize / 2, (Screen.width / 2) + boxSize / 2); //Limits mouse position to a square on the game screen
            mouseY = Mathf.Clamp(Input.gyro.attitude.y, (Screen.height / 2) - boxSize / 2, (Screen.height / 2) + boxSize / 2); //Limits mouse position to a square on the game screen
            //transform.Rotate(new Vector3(-Input.gyro.rotationRate.y, 0.0f, Input.gyro.rotationRate.x) * Time.deltaTime * speed, Space.World);
        }
        

        rotationX = (((mouseX/Screen.width) * newRange) / oldRange) - 45;
        rotationZ = (((mouseY/Screen.height) * newRange) / oldRange) - 45;

        transform.rotation = Quaternion.Euler(-rotationZ,0,rotationX);
        //*/


        //transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0.0f, 0.0f) * Time.deltaTime * speed, Space.World);
        //transform.Rotate(new Vector3(0.0f, 0.0f, Input.GetAxis("Mouse X")) * Time.deltaTime * speed, Space.World);

        /*
        if(rotationStyle == 0)
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0.0f, Input.GetAxis("Mouse X")) * Time.deltaTime * speed, Space.World);
            //transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -45, 45), 0, Mathf.Clamp(transform.eulerAngles.z, -45, 45));
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

        }
        else if(rotationStyle == 1)
        {
            transform.Rotate(new Vector3(-Input.gyro.rotationRate.y, 0.0f, Input.gyro.rotationRate.x) * Time.deltaTime * speed, Space.World);
        }
        //*/
    }

    void chooseRotationStyle()
    {
        #if UNITY_IOS
            rotationStyle = 1
        #elif UNITY_ANDROID
            rotationStyle = 1;
        #endif
    }
}
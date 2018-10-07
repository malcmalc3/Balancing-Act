using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPause : MonoBehaviour {

    public GameObject pauseButton;
    public GameObject pauseText;

	// Use this for initialization
	void Start ()
    {
        if (RotatePlatform.rotationStyle == 1)
        {
            pauseButton.SetActive(true);
        }
        else
        {
            pauseText.SetActive(true);
            StartCoroutine("FadePauseText");
        }
	}

    IEnumerator FadePauseText()
    {
        yield return new WaitForSeconds(5f);
        pauseText.SetActive(false);
    }
}

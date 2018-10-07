using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour {

    public AnimationClip fadeLogo;

    // Use this for initialization
    public void Start()
    {
        StartCoroutine(LoadAfterAnim());
    }

    public IEnumerator LoadAfterAnim()
    {
        yield return new WaitForSeconds(fadeLogo.length);
        SceneManager.LoadScene("StartingMenu");
    }
}

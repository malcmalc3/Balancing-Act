using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownAnimation : MonoBehaviour {

    public GameObject number;
    public Animation anim;
    //TextMeshPro numberText = number.GetComponent<TextMeshPro>();

    void Start()
    {
        StartCoroutine("ChangeNumber");
    }

    IEnumerator ChangeNumber()
    {
        for(int x=2; x>0; x--)
        {
            yield return new WaitForSeconds(1);
            number.GetComponent<TextMeshProUGUI>().text = x.ToString();
            //numberText.text = x.ToString();
            //number.GetComponent<Animator>().SetTrigger(Countdown);
            anim.enabled = true;
        }
    }
}

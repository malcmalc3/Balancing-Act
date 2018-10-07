using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    private void OnTriggerEnter()
    {
        Physics.gravity = new Vector3(0, 0, 0);
        FindObjectOfType<BallGravity>().GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);        
        gameManager.CompleteMenu();
    }
}
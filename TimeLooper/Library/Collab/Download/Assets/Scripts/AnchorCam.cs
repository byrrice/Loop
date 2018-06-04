using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorCam : MonoBehaviour {

    [SerializeField]GameObject leftAnchor;
    [SerializeField]GameObject rightAnchor;
	// Use this for initialization
	void Start () {
        Vector3 leftScreenAnchor = gameObject.GetComponent<Camera>().WorldToViewportPoint(leftAnchor.transform.position);
        Vector3 rightScreenAnchor = gameObject.GetComponent<Camera>().WorldToViewportPoint(rightAnchor.transform.position);
        while(leftScreenAnchor.x < 0 || rightScreenAnchor.x > 1)
        {
            leftScreenAnchor = gameObject.GetComponent<Camera>().WorldToViewportPoint(leftAnchor.transform.position);
            rightScreenAnchor = gameObject.GetComponent<Camera>().WorldToViewportPoint(rightAnchor.transform.position);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - .5f);
            Debug.Log("L: " + leftScreenAnchor + " R: " + rightScreenAnchor);
        }
    }
}

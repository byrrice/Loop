using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePad : MonoBehaviour {

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float delay;
	int i = 0;
	private Vector3 startPos;
     private AudioSource source;
	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
		startPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
    {
        transform.localScale = new Vector3(1f, .05f, 1f);
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - (.5f * (.95f * .1775f)), transform.localPosition.z);
        obstacle.SendMessage("Press"); // to be fixed
        source.Play();      
    }
	IEnumerator OnCollisionExit2D(Collision2D coll)
    {
        yield return new WaitForSeconds(delay); //allows for leeway 
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + (.5f * (.95f * .1775f)), transform.localPosition.z);
		transform.localScale = Vector3.one;
        obstacle.SendMessage("Release"); // to be fixed 
    }
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (i == 0) {
			
			transform.localScale = new Vector3 (1f, .05f, 1f);
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - (.5f * (.95f * .1775f)), transform.localPosition.z);
			obstacle.SendMessage ("Press"); // to be fixed
			source.Play ();
			i = 1;
		}
	}
	IEnumerator OnTriggerExit2D(Collider2D coll)
	{
		if(i == 1){
			yield return new WaitForSeconds(delay); //allows for leeway 
			transform.localPosition = startPos;
			//transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + (.5f * (.95f * .1775f)), transform.localPosition.z);
			transform.localScale = Vector3.one;
			obstacle.SendMessage("Release"); // to be fixed 
			i = 0;
		}
	}
}

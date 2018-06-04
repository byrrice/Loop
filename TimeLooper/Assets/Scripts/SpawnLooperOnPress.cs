using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(Damageable))]
//[RequireComponent(typeof(Damager))]
public class SpawnLooperOnPress : MonoBehaviour{
	
	public GameObject spawnObject;
	public float speed;
	public string spawnKey;
    public UnityEvent OnShadowSpawn;
    public myHealthUI ui;

    [SerializeField] private int numShadows = 6;
    private int numShadowsLeft;
    private Damager damager;
    private GameObject[] boxes;
    private int nextBoxIndex;
    private Damageable damageable;
	// Use this for initialization
	void Start () {
        boxes = new GameObject[numShadows];
        nextBoxIndex = 0;
        damageable = gameObject.GetComponent<Damageable>();
        damageable.startingHealth = numShadows;
        damager = gameObject.GetComponent<Damager>();
        numShadowsLeft = numShadows;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKeyDown(spawnKey))
            SpawnLooper();
	}
	void FixedUpdate () {
		foreach (GameObject box in boxes){
            if(box != null){
    			box.transform.position += Vector3.right * speed * Time.fixedDeltaTime;
                box.transform.Rotate(Vector3.back * speed);
            }
		}
	}
	void SpawnLooper(){
        if(nextBoxIndex >= numShadows) { return; } //don't spawn a shadow if we've already spawned them all
        GameObject spawned = Instantiate(spawnObject, transform.position, Quaternion.identity);
		boxes[nextBoxIndex] = spawned;
        nextBoxIndex++;

        numShadowsLeft--;
        damageable.SetHealth(numShadowsLeft);
        OnShadowSpawn.Invoke();
        ui.myUpdate(numShadowsLeft);
	}


}

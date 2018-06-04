using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnStill : MonoBehaviour {

    private bool moving = true;
    private const float DESPAWNTIME = 3; //in seconds
    private const float POSITIONTOLERANCE = .01f; //tolerance for telling if the object is moving
    float despawnTimer;
    Vector3 lastPosition = Vector2.zero;


    private void Start()
    {
        despawnTimer = Time.time;
    }

    void FixedUpdate () {
        UpdateMoving();
        lastPosition = transform.position;
        if (!moving && Time.time-despawnTimer > DESPAWNTIME)
        {
            Debug.Log("timed-despawning shadow");
            Destroy(gameObject);
        }
        else if(moving)
        {
            despawnTimer = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");
    }

    private void UpdateMoving()
    {
        //Debug.Log(lastPosition + ", " + transform.position);
        if (moving)
        {
            if (Vector3.Distance(transform.position, lastPosition) < POSITIONTOLERANCE)
            {
                moving = false;
                Debug.Log("shadow stopped moving");
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, lastPosition) >= POSITIONTOLERANCE)
            {
                moving = true;
                Debug.Log("shadow started moving");
            }
        }
    }

}

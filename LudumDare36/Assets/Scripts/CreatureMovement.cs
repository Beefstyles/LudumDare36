using UnityEngine;
using System.Collections;

public class CreatureMovement : MonoBehaviour {

    GameControlLoop gameControlLoop;
    CreatureMovePoint[] CreatureWaypoints;
    private bool hasTarget;
    private Transform moveTarget;
    private bool scannedForTargets;
    private float speed = 1F;
    
	// Use this for initialization
	void Start ()
    {
        hasTarget = false;
        scannedForTargets = false;

        gameControlLoop = FindObjectOfType<GameControlLoop>();
    }
	
	void Update ()
    {
        if (gameControlLoop.GameStarted)
        {
            if (!scannedForTargets)
            {
                CreatureWaypoints = FindObjectsOfType<CreatureMovePoint>();
                scannedForTargets = true;
            }
            
            if (!hasTarget)
            {
                GetNewTarget();
            }

            if (hasTarget)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, step);
                Debug.DrawLine(transform.position, moveTarget.position);
            }
        }
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rock" || coll.gameObject.tag == "Tree" || coll.gameObject.tag == "MovePoint")
        {
            Debug.Log("Getting new target due to hitting " + coll.gameObject.tag);
            hasTarget = false;
        }
    }

    void GetNewTarget()
    {
        moveTarget = CreatureWaypoints[Random.Range(0, CreatureWaypoints.Length)].gameObject.transform;
        hasTarget = true;
    }
}

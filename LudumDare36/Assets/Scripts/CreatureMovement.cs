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
            }
        }
	}

    void OnColliderEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Rock" || coll.gameObject.tag == "Tree")
        {
            Debug.Log("Getting new target");
            GetNewTarget();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "MovePoint")
        {
            GetNewTarget();
        }
    }

    void GetNewTarget()
    {
        moveTarget = CreatureWaypoints[Random.Range(0, CreatureWaypoints.Length)].gameObject.transform;
        hasTarget = true;
    }
}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    PlayerMovement PlayerMovement;
    Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(PlayerMovement == null)
        {
            PlayerMovement = FindObjectOfType<PlayerMovement>();
            if(PlayerMovement != null)
            {
                target = PlayerMovement.gameObject.transform;
            }
        }
    if(target != null)
        {
            transform.position = target.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10F);
        }
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float walkSpeed;
    private float currentSpeed;
    private float maxSpeed;
    public float PlayerWalkSpeed;
    public float PlayerSprintSpeed;

	void FixedUpdate ()
    {
        currentSpeed = PlayerWalkSpeed;
        maxSpeed = currentSpeed;
        if (Input.GetButton("Fire2"))
        {
            currentSpeed = PlayerSprintSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * currentSpeed, 0.8F), Mathf.Lerp(0, Input.GetAxis("Vertical") * currentSpeed, 0.8F));
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float walkSpeed;
    private float currentSpeed;
    private float maxSpeed;
    public float PlayerWalkSpeed;
    public float PlayerSprintSpeed;
    PlayerWeapons playerWeapons;
    private GameObject weaponUsed;
    Vector3 mousePos;

    void Start()
    {
        playerWeapons = GetComponent<PlayerWeapons>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

	void FixedUpdate ()
    {
        PlayerMovementControl();
        PlayerWeaponHandling();
    }

    void PlayerMovementControl()
    {
        currentSpeed = PlayerWalkSpeed;
        maxSpeed = currentSpeed;
        if (Input.GetButton("Fire2"))
        {
            currentSpeed = PlayerSprintSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * currentSpeed, 0.8F), Mathf.Lerp(0, Input.GetAxis("Vertical") * currentSpeed, 0.8F));
    }

    void PlayerWeaponHandling()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponUsed = Instantiate(playerWeapons.HuntingBoomerang, transform.position, Quaternion.identity) as GameObject;
            weaponUsed.GetComponent<Rigidbody2D>().AddForce(mousePos * 100);
        }
    }
}

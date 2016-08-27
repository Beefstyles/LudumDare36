using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float walkSpeed;
    private float currentSpeed;
    private float maxSpeed;
    public float PlayerWalkSpeed;
    public float PlayerSprintSpeed;
    PlayerWeapons playerWeapons;
    public GameObject weaponUsed;
    Vector3 mousePos;
    private float projectileSpeed = 5.0F;

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
            if (playerWeapons.NumberOfHuntingBoomerangs >= 1)
            {
                var pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 dir = target - myPos;
                dir.Normalize();
                weaponUsed = Instantiate(playerWeapons.HuntingBoomerang, myPos, Quaternion.identity) as GameObject;
                weaponUsed.GetComponent<Rigidbody2D>().velocity = dir * projectileSpeed;
                playerWeapons.NumberOfHuntingBoomerangs--;
            }
        }
    }
}

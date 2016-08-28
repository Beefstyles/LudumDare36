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
    Animator PlayerAnimator;

    void Start()
    {
        playerWeapons = GetComponent<PlayerWeapons>();
        PlayerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
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
        //GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * currentSpeed, 0.8F), Mathf.Lerp(0, Input.GetAxis("Vertical") * currentSpeed, 0.8F));
        if (Input.GetKey("up"))
        {
            PlayerAnimator.SetTrigger("Up");
            transform.Translate(0, currentSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("down"))
        {
            PlayerAnimator.SetTrigger("Down");
            transform.Translate(0, -currentSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("left"))
        {
            PlayerAnimator.SetTrigger("Left");
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            PlayerAnimator.SetTrigger("Right");
            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
        }

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
                var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
                weaponUsed = Instantiate(playerWeapons.HuntingBoomerang, transform.position, q) as GameObject;
                weaponUsed.GetComponent<Rigidbody2D>().AddForce(weaponUsed.transform.up * 500.0F);
                playerWeapons.NumberOfHuntingBoomerangs--;
            }
        }
    }
}

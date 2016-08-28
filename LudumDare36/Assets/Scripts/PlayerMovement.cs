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
    public Vector3 playerShootDirection;
    private SpriteRenderer playerSprite;
    public Sprite PlayerUp, PlayerDown, PlayerLeft, PlayerRight;
    public Transform Up, Down, Left, Right;
    private Vector3 ShootPoint;

    void Start()
    {
        playerWeapons = GetComponent<PlayerWeapons>();
        PlayerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            playerSprite.sprite = PlayerUp;
            transform.Translate(0, currentSpeed * Time.deltaTime, 0);
            playerShootDirection = Vector2.up;
            ShootPoint = Up.position;
        }
        else if (Input.GetKey("down"))
        {
            playerSprite.sprite = PlayerDown;
            transform.Translate(0, -currentSpeed * Time.deltaTime, 0);
            playerShootDirection = Vector2.down;
            ShootPoint = Down.position;
        }
        else if (Input.GetKey("left"))
        {
            playerSprite.sprite = PlayerLeft;
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
            playerShootDirection = Vector2.left;
            ShootPoint = Left.position;
        }
        else if (Input.GetKey("right"))
        {
            playerSprite.sprite = PlayerRight;
            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
            playerShootDirection = Vector2.right;
            ShootPoint = Right.position;
        }

    }

    void PlayerWeaponHandling()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerWeapons.NumberOfHuntingBoomerangs >= 1)
            {
                /*var pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
                weaponUsed = Instantiate(playerWeapons.HuntingBoomerang, transform.position, q) as GameObject;
                */
                weaponUsed = Instantiate(playerWeapons.HuntingBoomerang, ShootPoint, Quaternion.identity) as GameObject;
                //playerShootDirection.Normalize();
                //weaponUsed.GetComponent<Rigidbody2D>().AddForce(playerShootDirection * 1000.0F);
                //weaponUsed.transform.position = Vector3.MoveTowards(weaponUsed.transform.position, playerShootDirection, 100 * Time.deltaTime);
                //weaponUsed.GetComponent<Rigidbody2D>().velocity = playerShootDirection;
                //weaponUsed.transform.Translate(playerShootDirection * 50 * Time.deltaTime);
                //weaponUsed.GetComponent<HuntingBoomerang>().ShootDirection = playerShootDirection;
                weaponUsed.GetComponent<Rigidbody2D>().AddRelativeForce(playerShootDirection * 500);
                playerWeapons.NumberOfHuntingBoomerangs--;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class HuntingBoomerang : MonoBehaviour {

    Rigidbody2D rb;
    private bool isStationary;
    Vector3 oppositeVelocity;
    public float brakePower;
    private float delayTimer;
    public bool pickupable;
    PlayerWeapons playerWeapons;
    CreatureHealth creatureHealth;
    private int damage = 100;
    public Vector2 ShootDirection;

    void Start()
    {
        delayTimer = 1F;
        isStationary = false;
        pickupable = false;
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(15F);
        //rb.velocity = ShootDirection * 100;
    }

	void Update ()
    {
        if(delayTimer >= 0)
        {
            delayTimer -= Time.deltaTime;
        }
            if (!isStationary && delayTimer <= 0)
            {
                rb.Sleep();
                rb.freezeRotation = true;
                isStationary = true;
                pickupable = true;
            }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Creature")
        {
            creatureHealth = coll.gameObject.GetComponent<CreatureHealth>();
            creatureHealth.CreatureHlth -= damage;
        }

        if(coll.gameObject.tag == "Player")
        {
            if (pickupable)
            {
                playerWeapons = coll.gameObject.GetComponent<PlayerWeapons>();
                playerWeapons.NumberOfHuntingBoomerangs++;
                Destroy(gameObject);
            }
        }
    }
}

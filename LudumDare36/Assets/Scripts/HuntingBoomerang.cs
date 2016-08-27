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
	
    void Start()
    {
        delayTimer = 1F;
        isStationary = false;
        pickupable = false;
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(15F);
    }

	void Update ()
    {
        if(delayTimer >= 0)
        {
            delayTimer -= Time.deltaTime;
        }

        if (rb.velocity.x <= 0 || rb.velocity.y <= 0)
        {
            if (!isStationary && delayTimer <= 0)
            {
                rb.Sleep();
                rb.freezeRotation = true;
                isStationary = true;
                pickupable = true;
            }
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Creature")
        {

        }

        if(coll.gameObject.tag == "Player")
        {
            if (pickupable)
            {
                playerWeapons = coll.GetComponent<PlayerWeapons>();
                playerWeapons.NumberOfHuntingBoomerangs++;
                Destroy(gameObject);
            }
        }
    }
}

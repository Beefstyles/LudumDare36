using UnityEngine;
using System.Collections;

public class HuntingBoomerang : MonoBehaviour {

    Rigidbody2D rb;
    private bool isStationary;
    Vector3 oppositeVelocity;
    public float brakePower;
    private float delayTimer;
	
    void Start()
    {
        delayTimer = 1F;
        isStationary = false;
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(15F);
    }
	// Update is called once per frame
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
                isStationary = true;
            }
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Creature")
        {

        }
    }
}

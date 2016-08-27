using UnityEngine;
using System.Collections;

public class HuntingBoomerang : MonoBehaviour {

    Rigidbody2D rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(15F);
    }
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Creature")
        {

        }
    }
}

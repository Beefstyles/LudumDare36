using UnityEngine;
using System.Collections;

public class DeadCreaturePickup : MonoBehaviour {

    public int FoodProvided;
    PlayerFoodStore pf;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            pf = coll.GetComponent<PlayerFoodStore>();
            pf.CurrentPlayerFoodStore += FoodProvided;
        }
    }
}

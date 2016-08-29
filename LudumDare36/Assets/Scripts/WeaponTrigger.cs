using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour {

    PlayerWeapons playerWeapons;
    HuntingBoomerang hb;

    void Update()
    {
        if(hb == null)
        {
            hb = GetComponentInParent<HuntingBoomerang>();
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (hb.pickupable)
            {
                playerWeapons = coll.gameObject.GetComponent<PlayerWeapons>();
                playerWeapons.NumberOfHuntingBoomerangs++;
                hb.DestroyBoomerang();
            }
        }
    }
}

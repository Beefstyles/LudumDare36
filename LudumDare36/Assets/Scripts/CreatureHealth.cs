using UnityEngine;
using System.Collections;

public class CreatureHealth : MonoBehaviour {

    public int CreatureHlth = 100;
    public GameObject DeadCreature;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1F);
        Instantiate(DeadCreature, transform.position, Quaternion.identity);

    }
}

using UnityEngine;
using System.Collections;

public class CreatureHealth : MonoBehaviour {

    public int CreatureHlth = 100;
    public GameObject DeadCreature;
    private bool creatureDead;

	// Use this for initialization
	void Start ()
    {
        creatureDead = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(CreatureHlth <= 0 && !creatureDead)
        {
            creatureDead = false;
            StartCoroutine("Death");
        }
	}

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1F);
        Instantiate(DeadCreature, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

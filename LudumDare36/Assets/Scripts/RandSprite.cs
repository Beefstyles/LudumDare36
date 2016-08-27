using UnityEngine;
using System.Collections;

public class RandSprite : MonoBehaviour {

    public Sprite[] spriteArray;
    private SpriteRenderer unitSpriteRnd;

	// Use this for initialization
	void Start ()
    {
        if(gameObject.tag == "Rock")
        {
            spriteArray = Resources.LoadAll<Sprite>("Obstacles_Rocks");
        }
        else if(gameObject.tag == "Tree")
        {
            spriteArray = Resources.LoadAll<Sprite>("Trees");
        }

        unitSpriteRnd = GetComponentInChildren<SpriteRenderer>();
        unitSpriteRnd.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [System.Serializable]
    public class GameText
    {
        public Text WeaponChoice, WeaponChoiceRem;
    }

    PlayerWeapons playerWeapons;
    PlayerMovement playerMovement;
    public GameText gameText;

    void Start ()
    {
        playerWeapons = FindObjectOfType<PlayerWeapons>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(playerMovement.weaponUsed.name.ToString() != null)
        {
            gameText.WeaponChoice.text = playerMovement.weaponUsed.name.ToString();
        }

            gameText.WeaponChoiceRem.text = playerWeapons.NumberOfHuntingBoomerangs.ToString();

    }
}

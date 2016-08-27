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
        
    }
	
	void Update ()
    {
        if(playerWeapons == null || playerMovement == null)
        {
            playerWeapons = FindObjectOfType<PlayerWeapons>();
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        if (playerWeapons != null && playerMovement != null)
        {
            if (playerMovement.weaponUsed != null)
            {
                gameText.WeaponChoice.text = playerMovement.weaponUsed.name.ToString();
            }

            gameText.WeaponChoiceRem.text = playerWeapons.NumberOfHuntingBoomerangs.ToString();
        }
       

    }
}

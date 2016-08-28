using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [System.Serializable]
    public class GameText
    {
        public Text WeaponChoice, WeaponChoiceRem, PlayerFoodStore, TimeRemaining;
    }

    PlayerWeapons playerWeapons;
    PlayerMovement playerMovement;
    PlayerFoodStore playerFoodStore;
    public GameText gameText;

    void Start()
    {

    }

    void Update()
    {
        if (playerWeapons == null || playerMovement == null || playerFoodStore == null)
        {
            playerWeapons = FindObjectOfType<PlayerWeapons>();
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerFoodStore = FindObjectOfType<PlayerFoodStore>();
        }

        if (playerWeapons != null && playerMovement != null && playerFoodStore != null)
        {
            if (playerMovement.weaponUsed != null)
            {
                gameText.WeaponChoice.text = playerMovement.weaponUsed.name.ToString();
            }
            gameText.WeaponChoiceRem.text = playerWeapons.NumberOfHuntingBoomerangs.ToString();
            gameText.PlayerFoodStore.text = playerFoodStore.CurrentPlayerFoodStore.ToString();
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControlLoop : MonoBehaviour {
    public GameObject Player;
    private bool playerSpawned;
    public bool GameStarted;
    public Transform PlayerSpawnPoint;
    private int timeAvailable;
    private int numberOfKylees;
    private int currentLevel;
    private int foodRequired;
    private bool endOfRoundStarted;
    GameUI gameUI;
    PlayerFoodStore playerFoodStore;
    PlayerWeapons playerWeapons;

    void Start ()
    {
        Time.timeScale = 1.0F;
        gameUI.GameOnScreen.SetActive(true);
        gameUI.GameOverScreen.SetActive(false);
        gameUI = FindObjectOfType<GameUI>();
        timeAvailable = CarryOverInfo.TimeAvailable;
        numberOfKylees = CarryOverInfo.NumberOfKylees;
        currentLevel = CarryOverInfo.CurrentLevel;
        foodRequired = CarryOverInfo.FoodRequired;
        endOfRoundStarted = false;
    }
	
	void Update ()
    {
	    if(GameStarted && !playerSpawned)
        {
            Instantiate(Player, PlayerSpawnPoint.position, Quaternion.identity);
            playerSpawned = true;
        }

        if(timeAvailable >= 0)
        {
            timeAvailable -= (int)Time.deltaTime;
        }
        if(timeAvailable <= 0)
        {
            if (!endOfRoundStarted)
            {
                EndLevel();
                endOfRoundStarted = true;
            }
        }
	}

    void EndLevel()
    {
        playerFoodStore = FindObjectOfType<PlayerFoodStore>();
        playerWeapons = FindObjectOfType<PlayerWeapons>();
        Time.timeScale = 0.0F;
        gameUI.GameOnScreen.SetActive(false);
        gameUI.GameOverScreen.SetActive(true);
        /*
        public Text WeaponChoice, WeaponChoiceRem, PlayerFoodStore, TimeRemaining,
            WeekText, FoodHarvText, FoodReqText, KyleesRemText, StatusText;
        */
        gameUI.gameText.WeekText.text = CarryOverInfo.CurrentLevel.ToString();
        gameUI.gameText.FoodHarvText.text = playerFoodStore.CurrentPlayerFoodStore.ToString();
        gameUI.gameText.FoodReqText.text = CarryOverInfo.FoodRequired.ToString();
        gameUI.gameText.KyleesRemText.text = playerWeapons.NumberOfHuntingBoomerangs.ToString();
        if (playerFoodStore.CurrentPlayerFoodStore >= CarryOverInfo.FoodRequired)
        {
            EndGameSuccesful();
        }

        else
        {
            EndGameFailure();
        }
    }

    void EndGameSuccesful()
    {
        gameUI.gameText.StatusText.text = "You collected enough food to survive the week.";
        if (CarryOverInfo.CurrentLevel % 3 == 0)
        {
            gameUI.gameText.StatusText.text = "You collected enough food to survive the week. You have collected another person so your food requirement has gone up by 20";
            CarryOverInfo.FoodRequired += 20;
        }
        CarryOverInfo.NumberOfKylees = playerWeapons.NumberOfHuntingBoomerangs;
        CarryOverInfo.NumberOfKylees++;
        CarryOverInfo.CurrentLevel++;
        gameUI.RestartGame.enabled = true;
        gameUI.NextWeek.enabled = true;
    }

    void EndGameFailure()
    {
        gameUI.gameText.StatusText.text = "You were not succesful enough to survive. You survived " + CarryOverInfo.CurrentLevel.ToString() + " weeks";
        gameUI.RestartGame.enabled = true;
        gameUI.NextWeek.enabled = false;
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("MainLevel");
    }
}

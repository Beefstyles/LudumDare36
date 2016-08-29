using UnityEngine;
using System.Collections;

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

	void Start ()
    {
        Time.timeScale = 1.0F;
        timeAvailable = CarryOverInfo.TimeAvailable;
        numberOfKylees = CarryOverInfo.NumberOfKylees;
        currentLevel = CarryOverInfo.CurrentLevel;
        foodRequired = CarryOverInfo.FoodRequired;
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

        }
	}

    void EndLevel()
    {

    }
}

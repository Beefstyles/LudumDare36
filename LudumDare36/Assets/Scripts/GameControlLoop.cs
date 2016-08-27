using UnityEngine;
using System.Collections;

public class GameControlLoop : MonoBehaviour {
    public GameObject Player;
    private bool playerSpawned;
    public bool GameStarted;
    public Transform PlayerSpawnPoint;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(GameStarted && !playerSpawned)
        {
            Instantiate(Player, PlayerSpawnPoint.position, Quaternion.identity);
            playerSpawned = true;
        }
	}
}

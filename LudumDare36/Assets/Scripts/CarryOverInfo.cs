using UnityEngine;
using System.Collections;

public class CarryOverInfo : MonoBehaviour {

    static public int NumberOfKylees;
    static public int CurrentLevel;
    static public int FoodRequired;
    static public int TimeAvailable;
	
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}

}

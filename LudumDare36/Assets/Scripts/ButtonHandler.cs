using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

    /*
       static public int NumberOfKylees;
        static public int CurrentLevel;
        static public int FoodRequired;
        static public int TimeAvailable;
    */
    public void StartGame()
    {
        CarryOverInfo.NumberOfKylees = 5;
        CarryOverInfo.CurrentLevel = 1;
        CarryOverInfo.FoodRequired = 60;
        CarryOverInfo.TimeAvailable = 60;
        SceneManager.LoadScene("MainLevel");
    }
}

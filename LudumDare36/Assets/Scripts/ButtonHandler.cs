using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
}

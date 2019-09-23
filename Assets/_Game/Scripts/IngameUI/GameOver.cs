using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public void ReloadGame()
	{
		// Application.LoadLevel(Application.loadedLevel);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    // Update is called once per frame
    public void GoToMenu()
    {
	    SceneManager.LoadScene(sceneName: "MainMenu", LoadSceneMode.Single);
    }
}

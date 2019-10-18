using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	private void Start()
	{
		Time.timeScale = 0;
	}

	private void OnDisable()
	{
		Time.timeScale = 1;
	}

	public void Continue()
    {
	    Debug.Log("returning to game");
	    SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void RestartLevel()
    {
	    Application.LoadLevel (Application.loadedLevel);
    }

    public void BackToMenu()
    {
	    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

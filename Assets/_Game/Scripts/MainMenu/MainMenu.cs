using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private BoolVariable hasBeenLoaded;

	private void Start()
	{

		hasBeenLoaded.Value = true;
	}

	public void PlayGame()
	{
		Debug.Log("Loaded New Scene");


		// Merge between 10 and 3s
		SceneManager.LoadScene(13, LoadSceneMode.Single);


	}

	public void QuitGame()
	{
		hasBeenLoaded.Value = false;
		#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		UnityEditor.EditorApplication.isPlaying = false;
		#else
         Application.Quit();
		#endif

	}
}

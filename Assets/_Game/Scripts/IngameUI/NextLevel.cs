using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public void LoadNextLevel()
	{

		if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex+1 )
		{
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneIndex + 1);

		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenLevel : MonoBehaviour
{
	[SerializeField] public TextMeshProUGUI levelNumb;
	[SerializeField] private int levelnr;

	public void LoadLevel()
	{
		Debug.Log("Hello");
		Debug.Log(levelNumb.text);
		SceneManager.LoadScene(int.Parse(levelNumb.text) + 2, LoadSceneMode.Single);
	}

	public void LevelLoad()
	{
		SceneManager.LoadScene(levelnr + 2, LoadSceneMode.Single);

	}

	public void LoadLevel(int nr)
	{
		SceneManager.LoadScene(nr);
	}
	public void LoadLevelAdd(int nr)
	{
		SceneManager.LoadScene(nr,LoadSceneMode.Additive);
	}

	public void CloseLevelSub()
	{
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
		gameObject.GetComponent<InputManager>().ToggleSet();

	}
}

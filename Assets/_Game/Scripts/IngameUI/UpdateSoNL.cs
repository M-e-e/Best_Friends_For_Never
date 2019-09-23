using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateSoNL : MonoBehaviour
{

	private int currentLevelnum;
	[SerializeField] private IntVariable levelsnum;

	public void UpdateLevelsNum()
	{
		currentLevelnum = SceneManager.GetActiveScene().buildIndex;
		levelsnum.Value = currentLevelnum - 2;
	}
}

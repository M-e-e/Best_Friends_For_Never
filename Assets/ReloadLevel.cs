using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
	[SerializeField] private BoolVariable GameOver;
    public void Reload()
    {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    GameOver.Value = false;
    }
}

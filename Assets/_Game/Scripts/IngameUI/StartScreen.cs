using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class StartScreen : MonoBehaviour
{

	[SerializeField] private BoolVariable hasBeenLoaded;
	[SerializeField] private GameObject MainMenu;

	private void Start()
	{
		if (hasBeenLoaded.Value)
		{
			MainMenu.SetActive(true);
			this.gameObject.SetActive(false);
		}
		hasBeenLoaded.Value = true;
	}

    // Update is called once per frame
    void Update()
    {

    }
}

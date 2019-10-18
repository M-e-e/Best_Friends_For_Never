using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityAtoms;
using UnityEngine.SceneManagement;

public class LevelNrToUi : MonoBehaviour
{


		private TextMeshProUGUI LevelNr;



		// Start is called before the first frame update
		void Start()
		{
			LevelNr = transform.GetComponent<TextMeshProUGUI>();
			LevelNr.text =(SceneManager.GetActiveScene().buildIndex-3).ToString();

		}

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SelLevelManager : MonoBehaviour
{
	[SerializeField] private IntVariable levelsnum;
	public Button lvlaccessbtn;
	public int counter;
	public void OnEnable()
	{
		activateLevels();
	}

	public void activateLevels()
	{
		//LevelGrid = GameObject.FindGameObjectWithTag("SelLevelGrid");
		Debug.Log("entered activateLevels");
		if (counter == 0 && levelsnum.Value < 7)
		{ Debug.Log("eins");

			for (int i = 0; i < levelsnum.Value; i++)
			{

				lvlaccessbtn = this.transform?.GetChild(i).GetComponent<Button>();
				if (lvlaccessbtn!=null)
				{
					lvlaccessbtn.interactable = true;
				}
			}
		}else if (counter == 1 && levelsnum.Value < 14)
		{Debug.Log("zwei");
			for (int i = 0; i < levelsnum.Value-7; i++)
			{

				lvlaccessbtn = this.transform?.GetChild(i).GetComponent<Button>();
				if (lvlaccessbtn!=null)
				{
					lvlaccessbtn.interactable = true;
				}
			}
		}else if (counter == 2 && levelsnum.Value < 20)
		{Debug.Log("drei"+levelsnum.Value);
			for (int i = 0; i < levelsnum.Value - 14; i++)
			{
				Debug.Log("-");

				lvlaccessbtn = this.transform.GetChild(i).GetComponent<Button>();
				if (lvlaccessbtn != null)
				{
					lvlaccessbtn.interactable = true;
				}
			}
		}else{Debug.Log("vier");
				for (int i = 0; i < 7; i++)
				{

					lvlaccessbtn = this.transform?.GetChild(i).GetComponent<Button>();
					if (lvlaccessbtn!=null)
					{
						lvlaccessbtn.interactable = true;
					}
			}
		}







	}

}


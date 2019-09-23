using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ButtonSelect : MonoBehaviour
{
	public UnityEngine.UI.Button[] btn ;
	GameObject myEventSystem;

	private void Awake()
	{
		myEventSystem = GameObject.Find("EventSystem");
	}

	public void Select(Button btn)
	{
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn.gameObject);
	}
	public void SelectNextButton()
	{
		GameObject selected = myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject;

		Debug.Log("down event fired");
		for (int i = 0; i < btn.Length; i++)
		{
			if (btn[i].gameObject == selected)
			{
				if (i == btn.Length - 1)
				{
					myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn[0].gameObject);
					return;
				}

				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn[i + 1].gameObject);
			}
		}
	}

	public void SelectPrevButton()
	{
		GameObject selected = myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject;

		Debug.Log("up event fired");
		for (int i = 0; i < btn.Length; i++)
		{
			if (btn[i].gameObject == selected)
			{
				if (i == 0)
				{
					myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn[btn.Length - 1].gameObject);
					return;
				}
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn[i - 1].gameObject);
			}
		}
	}
}

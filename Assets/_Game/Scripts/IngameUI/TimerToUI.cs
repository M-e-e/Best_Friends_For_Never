using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms;
using UnityEngine;
using UnityEngine.UI;

public class TimerToUI : MonoBehaviour
{
	private TextMeshProUGUI Time;

	[SerializeField] private StringVariable TimeString;

	// Start is called before the first frame update
	void Start()
	{
		Time = transform.GetComponent<TextMeshProUGUI>();
		Time.text = TimeString.Value;

	}
}

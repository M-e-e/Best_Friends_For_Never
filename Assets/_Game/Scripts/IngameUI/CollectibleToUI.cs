using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleToUI : MonoBehaviour
{
	private TextMeshProUGUI Collectible;

		[SerializeField] private PickUpCounter CollectibleCounted;

		// Start is called before the first frame update
		void Start()
		{
			Collectible = transform.GetComponent<TextMeshProUGUI>();
			Collectible.text = (CollectibleCounted.value).ToString();

		}
}

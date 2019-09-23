using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityAtoms;

public class DeathToUI : MonoBehaviour
{
    private TextMeshProUGUI Deaths;

    [SerializeField] private IntVariable CountedDeaths;

    // Start is called before the first frame update
    void Start()
    {
	    Deaths = transform.GetComponent<TextMeshProUGUI>();
	    Deaths.text = (CountedDeaths.Value).ToString();

    }
}

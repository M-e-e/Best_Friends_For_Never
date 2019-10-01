using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleDebug : MonoBehaviour
{
	private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.P))
	    {
		    stop = !stop;

		    Time.timeScale = stop ? 0 : 1;
	    }
    }
}

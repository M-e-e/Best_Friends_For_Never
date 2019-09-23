using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using DG.Tweening;

public class Candle : MonoBehaviour
{
	[SerializeField] private float maxIntensity;

	[SerializeField] private float minIntensity;

	private Light2D light;

    void Start()
    {
	    light = GetComponent<Light2D>();

	    StartCoroutine(CandleLight());
    }

    IEnumerator CandleLight()
    {

	    while (true)
	    {
		    float topTarget = Random.Range(light.intensity, maxIntensity);
		    float lowTarget = Random.Range(light.intensity, minIntensity);

		    for (float f = .01f; f < Random.Range(.01f,1); f += .01f)
		    {
			    light.intensity = Mathf.Lerp(light.intensity, topTarget, f);
			    yield return null;
		    }

		    for (float f = .01f; f < Random.Range(.01f,1); f += .01f)
		    {
			    light.intensity = Mathf.Lerp(light.intensity, lowTarget, f);
			    yield return null;
		    }

	    }
    }
}

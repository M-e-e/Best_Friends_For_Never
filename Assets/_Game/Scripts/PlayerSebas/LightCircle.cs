using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightCircle : MonoBehaviour
{
	[SerializeField] private FloatVariable TimeSinceTouch;
	[SerializeField] private FloatVariable CurrentPlayerDistance;
	[SerializeField] private FloatVariable TimeBeforeDeath;
	[SerializeField] private FloatConstant DistanceBeforeDeath;
	[SerializeField] private FloatConstant MaxRadius;
	[SerializeField] private FloatConstant MinRadius;

	public float LightRadiusModifier = 0;

	private Light2D _light;

    // Start is called before the first frame update
    void Start()
    {
	    _light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    _light.intensity = Mathf.Min(0.55f,Mathf.Max(((TimeBeforeDeath.Value - TimeSinceTouch.Value) / TimeBeforeDeath.Value  / 1.5f),0.2f));
		Debug.Log(_light.intensity);

	    float LightRadius = (DistanceBeforeDeath.Value - CurrentPlayerDistance.Value) / DistanceBeforeDeath.Value * (MaxRadius.Value + LightRadiusModifier);
	    if (LightRadius > MinRadius.Value)
	    {
		    _light.pointLightOuterRadius = LightRadius;
	    }

    }
}

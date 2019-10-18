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
	[SerializeField] private StringConstant BigLight;
	public float LightRadiusModifier = 0;

	private Light2D _light, _bLight;
	[SerializeField] private GameObject _bigLightGameObject;

	// Start is called before the first frame update
    void Start()
    {
	    _light = GetComponent<Light2D>();
	    //_bigLightGameObject = AtomicTags.FindByTag(BigLight.Value);

	    _bLight = _bigLightGameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    Debug.Log(("script alive"));
	    float intensity = Mathf.Min(0.55f,Mathf.Max(((TimeBeforeDeath.Value - TimeSinceTouch.Value) / TimeBeforeDeath.Value  / 1.5f),0.2f));
	    float LightRadius = Mathf.Max((DistanceBeforeDeath.Value - CurrentPlayerDistance.Value) / DistanceBeforeDeath.Value * (MaxRadius.Value + LightRadiusModifier),MinRadius.Value);

		//Debug.Log(_light.intensity);
		//Debug.Log("Distance: " +CurrentPlayerDistance.Value);
		if (CurrentPlayerDistance.Value < 1)
		{

			_bigLightGameObject.SetActive(true);
			_light.transform.gameObject.SetActive(false);
			_bLight.intensity = intensity * 2;
			_bLight.pointLightOuterRadius = LightRadius;

		}
		else
		{
			_bigLightGameObject.SetActive(false);
			_light.transform.parent.gameObject.SetActive(true);
			_light.intensity = intensity;
			_light.pointLightOuterRadius = LightRadius;




		}



    }
}

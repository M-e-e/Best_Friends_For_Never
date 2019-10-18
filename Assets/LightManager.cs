using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightManager : MonoBehaviour
{
	[SerializeField] private FloatVariable TimeSinceTouch;
	[SerializeField] private FloatVariable CurrentPlayerDistance;
	[SerializeField] private FloatVariable TimeBeforeDeath;
	[SerializeField] private FloatConstant DistanceBeforeDeath;
	[SerializeField] private FloatConstant MaxRadius;
	[SerializeField] private FloatConstant MinRadius;
	[SerializeField] private StringConstant BigLight;
	[SerializeField] private StringConstant Lights;
		public float LightRadiusModifier = 0;

	private Light2D _light1,_light2 , _bLight;
	private GameObject _light1GameObject,_light2GameObject,_bigLightGameObject;

	// Start is called before the first frame update
	void Start()
	{
		_light1GameObject = AtomicTags.FindAllByTag(Lights.Value)[0];
		_light1 = _light1GameObject.GetComponent<Light2D>();
		_light2GameObject = AtomicTags.FindAllByTag(Lights.Value)[1];
		_light2 =_light2GameObject.GetComponent<Light2D>();
		_bigLightGameObject = AtomicTags.FindByTag(BigLight.Value);
		_bLight = _bigLightGameObject.GetComponent<Light2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(("script alive"));
		float intensity = Mathf.Min(0.5f,
			Mathf.Max(((TimeBeforeDeath.Value - TimeSinceTouch.Value) / TimeBeforeDeath.Value / 1.5f), 0.2f));
		float LightRadius =
			Mathf.Max(
				(DistanceBeforeDeath.Value - CurrentPlayerDistance.Value) / DistanceBeforeDeath.Value *
				(MaxRadius.Value + LightRadiusModifier), MinRadius.Value);

		//Debug.Log(_light.intensity);
		Debug.Log("Distance: " +CurrentPlayerDistance.Value);
		if (CurrentPlayerDistance.Value < 3)
		{

			_bigLightGameObject.SetActive(true);
			_light1GameObject.SetActive(false);
			_light2GameObject.SetActive(false);
			_bLight.intensity = intensity * 2;
			_bLight.pointLightOuterRadius = LightRadius;

		}
		else
		{
			_bigLightGameObject.SetActive(false);
			_light1GameObject.SetActive(true);
			_light2GameObject.SetActive(true);
			_light1.intensity = intensity;
			_light2.intensity = intensity;
			_light1.pointLightOuterRadius = LightRadius;
			_light2.pointLightOuterRadius = LightRadius;




		}
	}
}

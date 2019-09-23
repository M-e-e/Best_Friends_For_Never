using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/LightBuff")]
public class LightBuff : DeBuff
{
	[FormerlySerializedAs("BuffModier")] [SerializeField] private FloatVariable BuffModifier;
	[SerializeField] private FloatVariable TimeBeforeDeathModifier;

    public override void Apply(GameObject Target)
    {
	    Target.GetComponentInChildren<LightCircle>().LightRadiusModifier = BuffModifier.Value;

	    Target.GetComponent<PlayerTouching>().StartBlinkingIn.Value += TimeBeforeDeathModifier.Value;

	    Target.GetComponent<PlayerTouching>().TimeBeforeDeath.Value += TimeBeforeDeathModifier.Value;
    }
}

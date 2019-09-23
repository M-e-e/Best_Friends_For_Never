using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityAtoms.Extensions;

public class CalculatePlayerDistance : MonoBehaviour
{
	[SerializeField] private FloatVariable Distance;

	[SerializeField] private StringConstant TagPlayer2;

    void Update()
    {
	    Distance.Value = (AtomicTags.FindByTag(TagPlayer2.Value).transform.position - transform.position).magnitude;
    }
}

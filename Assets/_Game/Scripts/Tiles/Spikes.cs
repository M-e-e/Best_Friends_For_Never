using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
	[SerializeField] private VoidEvent deathEvent;

	[SerializeField] private StringConstant playerTag;


    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.HasTag(playerTag))
	    {
		    Debug.Log("Killed by spike, you looser!");
		    deathEvent.Raise();
	    }

	    if (other.gameObject.HasComponent<DeathCount>())
	    {
		    other.gameObject.GetComponent<DeathCount>().AddDeath();
	    }
    }
}

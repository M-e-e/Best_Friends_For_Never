using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
	[SerializeField] private PickUpCounter _counter;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
	    _counter.value++;
	    Destroy(gameObject);
    }
}

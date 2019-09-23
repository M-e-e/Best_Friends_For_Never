using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {
	}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

	    // wenn spieler gehittet, stirbt er
	    Destroy(gameObject);
    }
}

	using System;
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
	public Transform firepoint;
	public GameObject bulletPrefab;
	public float intervall;
	public int shotnum;
	public float shotdelay;
	public float delay;

	private void Start()
	{
		StartCoroutine(DelayShoot());
	}

	// Update is called once per frame
    void FixedUpdate()
    {
	    // wann geschossen werden soll bzw wie oft
	    // Shoot();
    }

    void Shoot()
    {
	    GameObject bullet=Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
	    bullet.transform.GetComponent<Rigidbody2D>().AddForce((firepoint.position - transform.position) * 10);
    }

    IEnumerator DelayShoot()
    {
	    yield return new WaitForSeconds(delay);
	    StartCoroutine(ShootCoroutine());

    }
    IEnumerator ShootCoroutine()
    {
	    for (int i = 0; i < shotnum; i++)
	    {
		    Shoot();
		    yield return new WaitForSeconds(shotdelay);
	    }

	    yield return new WaitForSeconds(intervall);
	    StartCoroutine(ShootCoroutine());
    }
}

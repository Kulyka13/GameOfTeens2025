using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private int bulletSpeed = 10;
	[SerializeField] private float shootDelay;
	private float timeAfterShooting;

	private void Update()
	{
		timeAfterShooting += Time.deltaTime;
		if (Input.GetButton("Fire1"))
		{
			if(timeAfterShooting >= shootDelay)
			{
				Shoot();
				timeAfterShooting = 0;
			}
		}
	}
	private void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * bulletSpeed;
	}
}

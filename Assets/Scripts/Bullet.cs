using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] int damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IDamageable damageable = collision.GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}

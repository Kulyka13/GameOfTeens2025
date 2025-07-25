using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] int damage;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}

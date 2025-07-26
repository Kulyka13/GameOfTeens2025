using UnityEngine;

public class EnemyTouchDamage : MonoBehaviour
{
	[SerializeField] private int damage = 10;

	private void OnTriggerEnter2D(Collider2D other)
	{
		HealthSystem health = other.GetComponent<HealthSystem>();
		if (health != null)
		{
			health.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}

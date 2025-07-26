using UnityEngine;

public class EnemyEvents : MonoBehaviour
{
	private HealthSystem healthSystem;

	private void Awake()
	{
		healthSystem = GetComponent<HealthSystem>();
	}

	private void OnEnable()
	{
		if (healthSystem != null)
			healthSystem.OnDeath += HandleDeath;
	}

	private void OnDisable()
	{
		if (healthSystem != null)
			healthSystem.OnDeath -= HandleDeath;
	}

	private void HandleDeath()
	{
		Debug.Log("Enemy Died!");
		Destroy(gameObject);
	}
}

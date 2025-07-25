using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
	private HealthSystem healthSystem;

	private void Awake()
	{
		healthSystem = GetComponent<HealthSystem>();
	}

	private void OnEnable()
	{
		if (healthSystem != null)
		{
			healthSystem.OnDeath += HandleDeath;
			healthSystem.OnDamageTaken += HandleDamageTaken;
		}
	}

	private void OnDisable()
	{
		if (healthSystem != null)
		{
			healthSystem.OnDeath -= HandleDeath;
			healthSystem.OnDamageTaken -= HandleDamageTaken;
		}
	}

	private void HandleDeath()
	{
		Debug.Log("Player Died!");
		gameObject.SetActive(false);
	}

	private void HandleDamageTaken(int damageAmount)
	{
		Debug.Log("Player took " + damageAmount + " damage!");
	}
}

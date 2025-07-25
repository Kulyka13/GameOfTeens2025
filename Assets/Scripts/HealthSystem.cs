using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
	[SerializeField] private int maxHealth = 100;
	private int currentHealth;

	public event System.Action OnDeath;
	public event System.Action<int> OnDamageTaken;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		OnDamageTaken?.Invoke(amount);

		if (currentHealth <= 0)
			Die();
	}

	private void Die()
	{
		OnDeath?.Invoke();
	}

	public int GetCurrentHealth() => currentHealth;
}

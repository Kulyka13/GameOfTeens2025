using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] private Vector2 targetPosition;       
	[SerializeField] private float moveSpeed = 2f;
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Vector2 currentPosition = rb.position;
		Vector2 direction = (targetPosition - currentPosition).normalized;
		rb.velocity = direction * moveSpeed;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rb.rotation = angle;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, targetPosition);
		Gizmos.DrawSphere(targetPosition, 0.2f);
	}
}

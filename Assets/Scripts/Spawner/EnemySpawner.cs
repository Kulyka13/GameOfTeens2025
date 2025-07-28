using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnInterval = 3f;
	public float spawnDistanceFromEdge = 2f;

	private Camera mainCam;

	private void Start()
	{
		mainCam = Camera.main;
		InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
	}

	void SpawnEnemy()
	{
		Vector2 spawnPos = GetRandomSpawnPositionNearCameraEdge();
		Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
	}

	Vector2 GetRandomSpawnPositionNearCameraEdge()
	{
		Vector3 bottomLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 topRight = mainCam.ViewportToWorldPoint(new Vector3(1, 1, 0));

		float x = 0, y = 0;

		int side = Random.Range(0, 4);

		switch (side)
		{
			case 0:
				x = bottomLeft.x - spawnDistanceFromEdge;
				y = Random.Range(bottomLeft.y, topRight.y);
				break;
			case 1:
				x = topRight.x + spawnDistanceFromEdge;
				y = Random.Range(bottomLeft.y, topRight.y);
				break;
			case 2:
				y = topRight.y + spawnDistanceFromEdge;
				x = Random.Range(bottomLeft.x, topRight.x);
				break;
			case 3:
				y = bottomLeft.y - spawnDistanceFromEdge;
				x = Random.Range(bottomLeft.x, topRight.x);
				break;
		}

		return new Vector2(x, y);
	}
}

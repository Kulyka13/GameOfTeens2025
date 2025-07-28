using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	[Header("Enemy Rules")]
	public List<EnemySpawnRule> enemyRules;

	[Header("Wave Points")]
	public List<WavePointData> customWavePoints;
	public int baseWavePoints = 5;
	public int extraPointsPerWave = 2;

	[Header("Wave Settings")]
	public float timeBetweenWaves = 5f;
	public float spawnDistanceFromEdge = 2f;
	public float spawnInterval = 0.5f; // Пауза між спавнами

	private int currentWave = 1;
	private float waveTimer;
	private Camera mainCam;
	private bool isSpawning = false;

	private void Start()
	{
		mainCam = Camera.main;
		StartCoroutine(SpawnWaveCoroutine());
	}

	private void Update()
	{
		if (!isSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
		{
			waveTimer += Time.deltaTime;
			if (waveTimer >= timeBetweenWaves)
			{
				currentWave++;
				StartCoroutine(SpawnWaveCoroutine());
				waveTimer = 0f;
			}
		}
	}

	IEnumerator SpawnWaveCoroutine()
	{
		isSpawning = true;

		int points = GetPointsForWave(currentWave);
		List<EnemySpawnRule> availableEnemies = enemyRules.FindAll(e => currentWave >= e.unlockWave);

		while (points > 0)
		{
			// Знаходимо всіх ворогів, які можна собі дозволити
			var affordableEnemies = availableEnemies.FindAll(e => e.cost <= points);
			if (affordableEnemies.Count == 0) break;

			// Випадковий ворог
			EnemySpawnRule chosen = affordableEnemies[Random.Range(0, affordableEnemies.Count)];

			Vector2 spawnPos = GetRandomSpawnPositionNearCameraEdge();
			Instantiate(chosen.enemyPrefab, spawnPos, Quaternion.identity);
			points -= chosen.cost;

			yield return new WaitForSeconds(spawnInterval);
		}

		isSpawning = false;
	}

	int GetPointsForWave(int wave)
	{
		foreach (var wp in customWavePoints)
		{
			if (wp.wave == wave)
				return wp.points;
		}

		return baseWavePoints + extraPointsPerWave * (wave - 1);
	}

	Vector2 GetRandomSpawnPositionNearCameraEdge()
	{
		Vector3 bottomLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 topRight = mainCam.ViewportToWorldPoint(new Vector3(1, 1, 0));

		float x = 0, y = 0;
		int side = Random.Range(0, 4);

		switch (side)
		{
			case 0: // ліво
				x = bottomLeft.x - spawnDistanceFromEdge;
				y = Random.Range(bottomLeft.y, topRight.y);
				break;
			case 1: // право
				x = topRight.x + spawnDistanceFromEdge;
				y = Random.Range(bottomLeft.y, topRight.y);
				break;
			case 2: // верх
				y = topRight.y + spawnDistanceFromEdge;
				x = Random.Range(bottomLeft.x, topRight.x);
				break;
			case 3: // низ
				y = bottomLeft.y - spawnDistanceFromEdge;
				x = Random.Range(bottomLeft.x, topRight.x);
				break;
		}

		return new Vector2(x, y);
	}
}

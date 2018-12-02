using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
	public HordeLeader Player;
    public Transform HorizontalSpawnPoint;
    public Transform TopOfSpawnPoint;
    public Transform BottomOfSpawnPoint;
    public float MinSpawnRate = 2f;
    public float MaxSpawnRate = 0.5f;
    public SpawnableObject[] SpawnTypes;

	private float spawnTimer = 2f;
	private float spawnBucket = 0f;

    void Update()
    {

		spawnBucket += Time.deltaTime;
		if (spawnBucket >= spawnTimer) {
			Spawn ();
			spawnTimer = Random.Range (MaxSpawnRate, MinSpawnRate);
			spawnBucket = 0.0f;
		}
    }

    void Spawn()
    {
        var spawn = GetNextSpawn();
        if (spawn == null)
            return;

		// find the best position here

		float randPos = Random.Range (BottomOfSpawnPoint.position.y, TopOfSpawnPoint.position.y);
		if (!spawn.isFriendly) {
			randPos = (Random.Range (0, 100) * 0.01f) * (Player.transform.position.y - randPos);
		}
		var newPosition = new Vector2(HorizontalSpawnPoint.position.x, randPos);

        Instantiate(spawn.Prefab, newPosition, Quaternion.LookRotation(Vector3.forward));
    }

    private SpawnableObject GetNextSpawn()
    {
        if (SpawnTypes.Length == 1)
            return SpawnTypes[0];

        var randomRoll = Random.Range(0f, 1f);
        float totalPercentage = 0f;

        SpawnableObject nextSpawn = null;
        foreach (var spawn in SpawnTypes)
        {
            totalPercentage += spawn.ProbabilityOfSpawn;
            if (randomRoll <= totalPercentage)
            {
                nextSpawn = spawn;
                break;
            }
        }

        return nextSpawn;
    }
}

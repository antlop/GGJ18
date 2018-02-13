using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public Transform HorizontalSpawnPoint;
    public Transform TopOfSpawnPoint;
    public Transform BottomOfSpawnPoint;
    public float MinSpawnRate = 2f;
    public float MaxSpawnRate = 0.5f;
    public float TimeToMaxSpawnRate = 300f;
    public SpawnableObject[] SpawnTypes;

    private float _lastSpawnTime;

    void Update()
    {
        var elapsedTime = GameController.ElapsedTime;

        var spawnRate = MinSpawnRate - ((MinSpawnRate - MaxSpawnRate) * (elapsedTime / TimeToMaxSpawnRate));
        var clampedSpawnRate = Mathf.Clamp(spawnRate, MaxSpawnRate, MinSpawnRate);

        if (clampedSpawnRate + _lastSpawnTime <= elapsedTime)
        {
            Spawn();
            _lastSpawnTime = elapsedTime;
        }
    }

    void Spawn()
    {
        var spawn = GetNextSpawn();
        if (spawn == null)
            return;

        var newPosition = new Vector2(HorizontalSpawnPoint.position.x, Random.Range(BottomOfSpawnPoint.position.y, TopOfSpawnPoint.position.y));

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

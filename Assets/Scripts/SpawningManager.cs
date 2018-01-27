using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public Transform HorizontalLocationOfSpawnPoint;
    public Transform TopOfSpawnPoint;
    public Transform BottomOfSpawnPoint;
    public float SpawnTime = 3f;
    public SpawnableObject[] SpawnTypes;
    
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    void Spawn()
    {
        var spawn = GetNextSpawn();
        if (spawn == null)
            return;

        var newPosition = new Vector2(HorizontalLocationOfSpawnPoint.position.x, Random.Range(BottomOfSpawnPoint.position.y, TopOfSpawnPoint.position.y));

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

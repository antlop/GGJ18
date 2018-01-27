using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform HorizontalLocationOfSpawnPoint;
    public Transform TopOfSpawnPoint;
    public Transform BottomOfSpawnPoint;
    public float SpawnTime = 3f;
    public Enemy[] Enemies;
    
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    void Spawn()
    {
        var enemy = GetNextEnemy();
        if (enemy == null)
            return;

        var newPosition = new Vector2(HorizontalLocationOfSpawnPoint.position.x, Random.Range(BottomOfSpawnPoint.position.y, TopOfSpawnPoint.position.y));

        Instantiate(enemy.Prefab, newPosition, Quaternion.LookRotation(Vector3.forward));
    }

    private Enemy GetNextEnemy()
    {
        var randomRoll = Random.Range(0f, 1f);
        float totalPercentage = 0f;

        Enemy nextEnemy = null;
        foreach (var enemy in Enemies)
        {
            totalPercentage += enemy.ProbabilityOfSpawn;
            if (randomRoll <= totalPercentage)
            {
                nextEnemy = enemy;
                break;
            }
        }

        return nextEnemy;
    }
}

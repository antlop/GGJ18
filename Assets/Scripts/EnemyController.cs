using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] Launchers;
    public float AttackRating = 1f;
    public GameObject ProjectilePrefab;

    void Start()
    {
        InvokeRepeating("Fire", AttackRating, AttackRating);
    }

    void Fire()
    {
        foreach (var launcher in Launchers)
        {
            Instantiate(ProjectilePrefab, launcher.position, launcher.rotation);
        }
    }
}

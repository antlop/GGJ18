using UnityEngine;

[CreateAssetMenu(menuName = "Erithroblast/Enemy")]
public class Enemy : ScriptableObject
{
    public float ProbabilityOfSpawn;
    public GameObject Prefab;
}

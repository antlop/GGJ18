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
		int i = 0; 
        foreach (var launcher in Launchers)
        {
			GameObject obj = Instantiate (ProjectilePrefab, transform.GetChild (0).GetChild (i).position, transform.rotation)as GameObject;
           // Instantiate(ProjectilePrefab, launcher.position, launcher.rotation);
			obj.transform.Rotate(new Vector3(0,0,1), i*45.0f);
			i++;

			//obj.GetComponent<Rigidbody2D> ().AddForce (obj.transform.forward * 10 * Time.deltaTime);
        }
    }
}

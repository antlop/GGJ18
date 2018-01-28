using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] Launchers;
    public float AttackRating = 1.5f;
    public GameObject ProjectilePrefab;

    void Start()
    {
        //InvokeRepeating("Fire", AttackRating, AttackRating);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // do stuff
            Destroy(gameObject);
        }
    }

    void Fire()
    {
		int i = 0; 
        foreach (var launcher in Launchers)
        {
			GameObject obj = Instantiate (ProjectilePrefab, transform.position, transform.rotation)as GameObject;
			// Instantiate(ProjectilePrefab, launcher.position, launcher.rotation);
			obj.transform.Rotate(new Vector3(0,0,1), i*90.0f);
			i++;

			//obj.GetComponent<Rigidbody2D> ().AddForce (obj.transform.forward * 100 * Time.deltaTime);
        }
    }
}

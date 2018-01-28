using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 20.0f;

    private Rigidbody2D _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
       // _rigidbody.velocity = new Vector2(Speed, 0);
		Debug.Log(transform.forward);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // do stuff
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
		Debug.Log ("update");
        _rigidbody.AddForce(transform.forward * Speed);
        //_rigidbody.velocity = new Vector2(Speed, 0);
    }
}

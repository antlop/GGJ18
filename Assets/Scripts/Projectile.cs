using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 2f;

    private Rigidbody2D _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(Speed, 0);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // do stuff
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * Speed);
        //_rigidbody.velocity = new Vector2(Speed, 0);
    }
}

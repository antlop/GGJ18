using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 0.01f;

    private Rigidbody2D _rigidbody;

	public Vector3 forward;
	private bool doOnce = true;

    public void Awake()
    {
       // _rigidbody.velocity = new Vector2(Speed, 0);
    }

	public void Start() {
		_rigidbody = GetComponent<Rigidbody2D>();
		Destroy (gameObject, 2.0f);
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
		Vector3 forward = transform.TransformDirection (Vector3.right);

		Debug.Log ("update");
		Debug.Log (forward);
		_rigidbody.AddForce(forward * Time.deltaTime * Speed);
		//GetComponent<Rigidbody2D>().velocity = transform.forward * 100;


		float angle = Mathf.Atan2(forward.y, forward.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

    }
}

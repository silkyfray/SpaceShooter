using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float speed;
    private Rigidbody rigidBody;
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    rigidBody = GetComponent<Rigidbody>();
	    _transform = GetComponent<Transform>();
        rigidBody.velocity = _transform.forward * speed;
	}

}

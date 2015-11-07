using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float speed;
    private Rigidbody rigidBody;
    private Transform transform;

	// Use this for initialization
	void Start ()
	{
	    rigidBody = GetComponent<Rigidbody>();
	    transform = GetComponent<Transform>();
        rigidBody.velocity = transform.forward * speed;
	}

}

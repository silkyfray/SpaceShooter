﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
};


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3
            (
                Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
            );

        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x *-tilt);
    }
}

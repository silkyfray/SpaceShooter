﻿using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;

    }

}

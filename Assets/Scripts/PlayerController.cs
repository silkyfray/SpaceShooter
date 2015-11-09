using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

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

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, transform.position, transform.rotation);
        }
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

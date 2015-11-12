using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    private Transform transform;

    public void Start()
    {
        transform = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Transform playerTransform = other.GetComponent<Transform>();

            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);

        }
    }
}

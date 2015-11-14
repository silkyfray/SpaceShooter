using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    private Transform _transform;
    public int scoreValue;
    private GameController gameController;

    public void Start()
    {
        _transform = GetComponent<Transform>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, _transform.position, _transform.rotation);

        if (other.tag == "Player")
        {
            Transform playerTransform = other.GetComponent<Transform>();

            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);
            gameController.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);

    }
}

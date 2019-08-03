using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{   
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {   if (other.CompareTag ("Boundary") || other.CompareTag  ("Powerup"))
        {
            return;
        }
        if (explosion != null)
        {    
        Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag ("Player") || other.CompareTag ("Powerup"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag ("Bolt") || other.CompareTag ("Powerup"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        gameController.AddScore (scoreValue);
        Destroy(gameObject);
    }
}
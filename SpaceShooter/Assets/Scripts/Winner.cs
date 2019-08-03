using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;

    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (gameController.score >= 100)
        {
            Destroy(gameObject);
        }
    }
}

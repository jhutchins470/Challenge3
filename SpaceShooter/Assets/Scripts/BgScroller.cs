using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizedZ;
    private Vector3 startPosition;
    private GameController gameController;
    // Start is called before the first frame update
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
        
        startPosition = transform.position;
    }

    void Update()
    {
      float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizedZ);
      transform.position = startPosition + Vector3.forward * newPosition;
    
    if (gameController.score >= 100)
    {
      scrollSpeed = 10;
    }
    }
}

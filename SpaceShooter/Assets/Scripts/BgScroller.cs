﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizedZ;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
      float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizedZ);
      transform.position = startPosition + Vector3.forward * newPosition;
    }
}

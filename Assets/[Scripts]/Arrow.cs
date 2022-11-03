using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float vertDistance = 1.0f;
   
    public float vertSpeed = 1.0f;
    public Vector2 startPoint;

    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * vertSpeed, vertDistance) + startPoint.y, 0.0f);
    }
}

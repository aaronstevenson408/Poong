using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.66f;
    public float moveSpeed = 1.0f;


    void Start()
    {
        Vector2 dir = Vector2.left;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);    
        rb2d.velocity = dir * moveSpeed;
    }
}

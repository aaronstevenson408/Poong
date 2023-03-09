using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d.velocity = Vector2.left;
    }
}
